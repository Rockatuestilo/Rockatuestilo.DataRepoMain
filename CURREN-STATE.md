Below is an **updated** “Current State of CMS Database” document, reflecting the **recent schema changes**. The key updates include the **new `Articles` table definition**, the introduction of **views** (`tb_news` and `news_categories`) to maintain backward compatibility with older table references, and some structural changes in the `Categories` table. 

---

# Current State of CMS Database

## Overview
The CMS database (schema name "`cmsbackup`" or "`blazares`") has been updated to better align with modern practices while **avoiding breaking changes**. Several existing tables remain as they were, but notable changes include the **creation of a new `Articles` table** (with more consistent column names and some UTF8 collations) and **two new views** (`tb_news`, `news_categories`) that expose the new structures using legacy column names.

This document provides a baseline of the **current** schema, highlighting table purposes, important columns, and notes on their usage or potential for future enhancements.

---

## Existing Tables

### 1. `Users`
**Purpose**: Stores information about system users.

| **Column Name**     | **Data Type**   | **Description**                                       |
|---------------------|-----------------|-------------------------------------------------------|
| `Id`                | INT             | Primary key.                                          |
| `Name`              | VARCHAR(60)     | First name of the user.                               |
| `LastName`          | VARCHAR(60)     | Last name of the user.                                |
| `LoginName`         | VARCHAR(60)     | Unique login name.                                    |
| `CreatedDate`       | TIMESTAMP       | Date and time of account creation.                    |
| `UpdatedDate`       | TIMESTAMP       | Date and time of last update.                         |
| `Password`          | VARCHAR(1500)   | Encrypted password (hash + salt).                     |
| `LastLogin`         | DATETIME        | Last login timestamp.                                 |
| `UserRoleLevel`     | INT             | Role/permission level (basic integer-based).          |
| `Email`             | VARCHAR(255)    | User email address.                                   |
| `VerifiedAccount`   | BIT(1)          | Indicates if the account is verified.                 |
| `Guid`              | CHAR(36)        | Globally unique identifier for the user record.       |

**Notes**:
- Roles are still stored as integers, limiting granularity without further role tables.
- Ensure modern password hashing practices (bcrypt/Argon2) for `Password`.

---

### 2. `Articles`
**Purpose**: Manages content such as blog posts, news items, or articles.  
*(Newly introduced or significantly revised table)*

| **Column Name**      | **Data Type**                               | **Description**                                                     |
|----------------------|---------------------------------------------|---------------------------------------------------------------------|
| `Id`                 | INT (AUTO_INCREMENT)                        | Primary key.                                                         |
| `Owner`              | INT                                         | ID of the user who owns/created the article.                        |
| `Title`              | VARCHAR(2000) (utf8mb4 collation)           | Title of the article.                                               |
| `Content`            | LONGTEXT (utf8mb4 unicode collation)        | Main body of the article.                                           |
| `CreatedDate`        | DATETIME                                    | Creation date of the article.                                       |
| `LastUpdateDate`     | DATETIME ON UPDATE CURRENT_TIMESTAMP        | Last update timestamp.                                              |
| `Permission`         | INT                                         | Permission level for the article.                                   |
| `ChangedById`        | INT                                         | User ID of the last person who modified this article.               |
| `CategoryId`         | INT                                         | Related category ID (no enforced FK).                               |
| `PublicationType`    | INT (default 0)                             | Numeric indicator of publication type.                              |
| `GalleryId`          | INT                                         | Associated gallery ID.                                              |
| `Presentation`       | LONGTEXT (utf8mb4 unicode collation)        | Additional display/presentation data.                               |
| `PublicationDate`    | TIMESTAMP (default CURRENT_TIMESTAMP)       | Publication date/time.                                              |
| `TitleForUrl`        | VARCHAR(500) (utf8mb3)                      | Slug or URL-friendly title.                                         |
| `HashtagsArticleId`  | INT                                         | Reference to associated hashtags.                                   |
| `ArticleVersion`     | INT                                         | Version indicator for the article.                                  |
| `OwnerUsersGuid`     | CHAR(36)                                    | GUID for the user who owns the article.                             |
| `Guid`               | CHAR(36) (default UUID)                     | Globally unique identifier for the article.                         |

**Indexes**:
- `idx_category_id` on `(CategoryId)`
- `idx_publicationdate` on `(PublicationDate)`

**Notes**:
- Collation mix: The table default is `latin1`, but text columns are set to `utf8mb4` or `utf8mb3`. This works but might be unified in future steps.
- The new columns `OwnerUsersGuid` and `Guid` give more flexible ways to track ownership and identity.

**Legacy Compatibility**:
- A **view** named **`tb_news`** exposes this table under older column aliases (e.g., `newsID`, `newsTittel`, etc.) for **backward compatibility**.

---

### 3. `Categories`
*(Previously referred to in legacy code as `news_categories`; now directly named `categories`, with a matching view for legacy.)*

**Purpose**: Defines article categories (and in older references, news categories).

| **Column Name**       | **Data Type**                  | **Description**                                              |
|-----------------------|--------------------------------|--------------------------------------------------------------|
| `news_categoriesID`   | INT (default 0)                | Primary key (legacy naming).                                |
| `categoryOwner`       | INT                            | ID of the user who owns the category.                       |
| `news_categoryName`   | VARCHAR(255)                   | Name of the category (older naming).                        |
| `levelCategory`       | INT                            | Hierarchical level of the category.                         |
| `CreatedByID`         | INT                            | ID of the creator.                                          |
| `UpdatedByID`         | INT                            | ID of the last updater.                                     |
| `CreatedDate`         | DATETIME                       | Creation date.                                              |
| `updatedDate`         | DATETIME                       | Last update date.                                           |
| `Guid`                | CHAR(36) (default UUID)         | Globally unique identifier for the category.                |

**Notes**:
- A **view** named **`news_categories`** maps to this table with legacy column naming for older code.
- Hierarchical relationships remain relatively simplistic (`levelCategory` int). 
- Potential improvement: a parent-child approach or a more flexible taxonomy system.

---

### 4. `CMSLog`
**Purpose**: Stores system logs for debugging and auditing.

| **Column Name** | **Data Type**   | **Description**                                                |
|-----------------|-----------------|----------------------------------------------------------------|
| `Id`            | INT             | Primary key.                                                   |
| `Date`          | DATETIME        | Date/time of the log entry.                                    |
| `Thread`        | VARCHAR(255)    | Thread identifier.                                             |
| `Level`         | VARCHAR(50)     | Severity level (e.g., INFO, WARN, ERROR).                      |
| `Logger`        | VARCHAR(255)    | Logger name or identifier.                                     |
| `Message`       | VARCHAR(4000)   | Log message content.                                           |
| `Exception`     | VARCHAR(2000)   | Exception details, if applicable.                              |

**Notes**:
- No purging/archiving mechanism is in place, so table size may grow indefinitely.
- Could consider a separate archival strategy or a rotating log approach.

---

### 5. `Roles`
**Purpose**: Defines user roles and associated permissions.

| **Column Name**    | **Data Type**    | **Description**                                     |
|--------------------|------------------|-----------------------------------------------------|
| `Id`               | INT              | Primary key.                                        |
| `Name`             | VARCHAR(30)      | Role name (Admin, Editor, etc.).                   |
| `Code`             | VARCHAR(255)     | Unique role code.                                   |
| `Description`      | VARCHAR(255)     | Describes the purpose/responsibilities of the role. |
| `Active`           | BIT(1)           | Indicates if the role is active.                    |
| `CreatedDate`      | DATETIME         | When the role was created.                          |
| `UpdatedDate`      | DATETIME         | Last time this role was updated.                    |

**Notes**:
- Still minimal granularity for advanced permissioning (i.e., no explicit RBAC table for per-action permissions).

---

### Other Noteworthy Tables

- **`Associations`**: Tracks object-to-object associations (via GUIDs referencing `Types`), enabling flexible linking between entities.  
- **`Galleries`**: Manages media galleries (paths, names) but lacks comprehensive metadata or advanced management fields.  
- **`Hashtags`, `HashtagsNews`**: Provides a hashtag system for content, though currently limited in scope (no robust taxonomy features).  
- **`GenericPreviewImages`**: Stores base64 strings and some metadata for preview images.  
- **`VersionInfo`**: Tracks **system-level** versioning (e.g., for migrations), **not** content versioning.  
- **`SubjectMedia`, `SubjectRelationships`, `Subjects`**: A set of tables used to model “subjects,” their media, and relationships (e.g., “Related,” “PartOf,” etc.).  

**Legacy/Backup Tables**  
- **`tb_news_backup`, `news_categories_backup`, `Articles_backup`**: Old backup tables or transitional storage.  
- **`pendingRegistration`**: Table for user registrations pending approval or confirmation.  
- **`categorylevels`**: Additional table for categorization or hierarchical definitions.

**Views**  
- **`tb_news`**: Maps the new `Articles` table to older naming conventions (e.g., `newsID`, `newsTittel`).  
- **`news_categories`**: Maps the `Categories` table to older naming conventions (`news_categoriesID`, etc.).

---

## Gaps and Opportunities

1. **Missing Features**:
   - **Content Versioning** for articles (beyond manual backup tables).
   - **Flexible Taxonomy** (tags, parent-child categories, custom groupings).
   - **Workflow Management** (draft, review, publish).
   - **Enhanced Media Library** with richer metadata (beyond `GenericPreviewImages`).
   - **User Profile Extensions** (avatars, roles by ID vs. integer, etc.).

2. **Redundancies**:
   - Backup tables overlap with the new `Articles` table and hamper clarity.  
   - Presentation data is partly in `Articles.Presentation` and could be separated (e.g., design layer vs. content layer).

3. **Potential Improvements**:
   - **Foreign Keys**: Currently lacking in some areas (e.g., `Articles.CategoryId` → `Categories.news_categoriesID`) could enforce referential integrity.  
   - **Unified Collation/Character Sets**: The database still mixes `latin1`, `utf8mb3`, and `utf8mb4`. Standardizing would reduce confusion.  
   - **Granular RBAC**: Expand `Roles` to store more detailed permissions, or adopt a role-to-user bridging table.

---

## Next Steps

1. **Evaluate** schema against immediate and long-term CMS needs (versioning, advanced relationships).  
2. **Consolidate** or phase out backup tables once the new `Articles` structure and views are fully adopted.  
3. **Enhance** indexing, foreign keys, and possibly unify collation to improve performance and consistency.  
4. **Plan** for advanced features: multi-language support, workflow states, or a more flexible taxonomy/tag system.

