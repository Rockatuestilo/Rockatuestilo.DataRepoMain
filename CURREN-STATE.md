# Current State of CMS Database

## Overview
The CMS database for `cmsbackup` has been analyzed to document its current state, including the tables, their structure, and their relationships. This document serves as a baseline for identifying gaps, redundancies, and areas for future improvement.

## Existing Tables

### 1. `Users`
**Purpose**: Stores information about system users.

| Column Name       | Data Type      | Description                           |
|-------------------|----------------|---------------------------------------|
| Id                | INT            | Primary key.                          |
| Name              | VARCHAR(60)    | First name of the user.               |
| LastName          | VARCHAR(60)    | Last name of the user.                |
| LoginName         | VARCHAR(60)    | Unique login name.                    |
| CreatedDate       | TIMESTAMP      | Date and time of account creation.    |
| UpdatedDate       | TIMESTAMP      | Date and time of last update.         |
| Password          | VARCHAR(1500)  | Encrypted password.                   |
| LastLogin         | DATETIME       | Last login timestamp.                 |
| UserRoleLevel     | INT            | Role/permission level.                |
| Email             | VARCHAR(255)   | User email address.                   |
| VerifiedAccount   | BIT(1)         | Account verification status.          |
| Guid              | CHAR(36)       | Globally unique identifier.           |

**Notes**:
- User roles are handled as an integer value, which may limit extensibility.
- Password storage should ensure compliance with modern security practices (e.g., hashing).

---

### 2. `Articles`
**Purpose**: Manages content such as blog posts or articles.

| Column Name         | Data Type        | Description                           |
|---------------------|------------------|---------------------------------------|
| ID                  | INT              | Primary key.                          |
| Owner               | INT              | ID of the user who owns the article.  |
| Title               | VARCHAR(2000)    | Article title.                        |
| Content             | TEXT             | Article content.                      |
| CreatedDate         | DATETIME         | Date the article was created.         |
| LastUpdateDate      | DATETIME         | Last update timestamp.                |
| Permission          | INT              | Permission level for the article.     |
| ChangedByID         | INT              | User ID of the last modifier.         |
| CategoryID          | INT              | Related category ID.                  |
| PublicationType     | INT              | Type of publication.                  |
| GalleryID           | INT              | Associated gallery ID.                |
| Presentation        | VARCHAR(2000)    | Additional display data.              |
| PublicationDate     | DATETIME         | Publication date of the article.      |
| TitleForURL         | VARCHAR(500)     | Slugified title for URL.              |
| HashtagsArticleId   | INT              | Associated hashtags.                  |
| ArticleVersion      | VARCHAR(2)       | Article version identifier.           |

**Notes**:
- The `CategoryID` column references categories but lacks enforced relationships.
- Presentation and URL management could be streamlined.

---

### 3. `Categories`
**Purpose**: Defines article categories.

| Column Name       | Data Type      | Description                           |
|-------------------|----------------|---------------------------------------|
| categoryID        | INT            | Primary key.                          |
| categoryOwner     | INT            | ID of the user who owns the category. |
| categoryName      | VARCHAR(255)   | Name of the category.                 |
| levelCategory     | INT            | Hierarchical level of the category.   |
| CreatedByID       | INT            | ID of the creator.                    |
| UpdatedByID       | INT            | ID of the last updater.               |
| CreatedDate       | DATETIME       | Creation date.                        |
| updatedDate       | DATETIME       | Last update date.                     |

**Notes**:
- Hierarchical categories are limited and not flexible enough for a modern CMS.
- No provision for custom taxonomy types (e.g., tags).

---

### 4. `CMSLog`
**Purpose**: Stores system logs for debugging and auditing purposes.

| Column Name | Data Type     | Description                           |
|-------------|---------------|---------------------------------------|
| Id          | INT           | Primary key.                          |
| Date        | DATETIME      | Log entry date.                       |
| Thread      | VARCHAR(255)  | Thread identifier.                    |
| Level       | VARCHAR(50)   | Log severity level.                   |
| Logger      | VARCHAR(255)  | Logger name or identifier.            |
| Message     | VARCHAR(4000) | Log message content.                  |
| Exception   | VARCHAR(2000) | Exception message (if applicable).    |

**Notes**:
- Lacks purging or archiving mechanism, leading to potential performance degradation.

---

### 5. `Roles`
**Purpose**: Defines user roles and permissions.

| Column Name    | Data Type      | Description                           |
|----------------|----------------|---------------------------------------|
| Id             | INT            | Primary key.                          |
| Name           | VARCHAR(30)    | Role name.                            |
| Code           | VARCHAR(255)   | Unique role code.                     |
| Description    | VARCHAR(255)   | Description of the role.              |
| Active         | BIT(1)         | Indicates if the role is active.      |
| CreatedDate    | DATETIME       | Creation date.                        |
| UpdatedDate    | DATETIME       | Last update date.                     |

**Notes**:
- Minimal granularity for permissions.

---

### Other Noteworthy Tables

- **`Associations`**: Tracks associations between objects (e.g., Articles, Categories).
- **`Galleries`**: Manages media galleries but lacks comprehensive metadata.
- **`Hashtags`**: Tracks hashtags but is limited in flexibility and extensibility.
- **`VersionInfo`**: Tracks versioning but only at a system level, not for content.

---

## Gaps and Opportunities

1. **Missing Features**:
   - Content versioning for articles.
   - Flexible taxonomy system (tags, custom groups).
   - Workflow and publication statuses (draft, review, publish).
   - Media library with metadata support.
   - User profile extensions (avatars, preferences).

2. **Redundancies**:
   - Presentation fields overlap with content structure.
   - Logs lack an archival mechanism, leading to potential performance issues.

3. **Potential Improvements**:
   - Enforce relationships through application logic or foreign keys.
   - Use normalized and flexible schemas for scalability.
   - Implement role-based access control (RBAC) with granularity.

---

## Next Steps
1. Evaluate the schema against future CMS requirements.
2. Redesign tables for scalability, flexibility, and modularity.
3. Integrate database-agnostic validation and optimization practices.

This documentation will serve as a reference for restructuring the database and aligning it with modern CMS standards.

