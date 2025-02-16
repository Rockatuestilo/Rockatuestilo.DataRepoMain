# Future State of CMS Database

## Required Tables for a Modern CMS

Below is the proposed list of tables that a modern CMS database should include to cover all necessary functionalities, improve flexibility, and ensure scalability.

### 1. **Users**
**Purpose**: Manages user accounts and their metadata.

| Column Name       | Data Type      | Description                             |
|-------------------|----------------|-----------------------------------------|
| UserID            | UUID           | Primary key.                            |
| Name              | VARCHAR(255)   | First name of the user.                 |
| LastName          | VARCHAR(255)   | Last name of the user.                  |
| Email             | VARCHAR(255)   | User email address (unique).            |
| PasswordHash      | VARCHAR(255)   | Encrypted password hash.                |
| RoleID            | UUID           | Foreign key to the `Roles` table.       |
| Avatar            | TEXT           | URL or path to the user’s profile picture.|
| IsVerified        | BOOLEAN        | Indicates account verification status.  |
| CreatedAt         | TIMESTAMP      | Account creation timestamp.             |
| UpdatedAt         | TIMESTAMP      | Last updated timestamp.                 |

---

### 2. **Roles**
**Purpose**: Defines roles and their associated permissions.

| Column Name       | Data Type      | Description                             |
|-------------------|----------------|-----------------------------------------|
| RoleID            | UUID           | Primary key.                            |
| Name              | VARCHAR(255)   | Role name (e.g., Admin, Editor).        |
| Description       | TEXT           | Description of the role.                |
| Permissions       | JSON           | Serialized permissions for the role.    |
| CreatedAt         | TIMESTAMP      | Role creation timestamp.                |
| UpdatedAt         | TIMESTAMP      | Last updated timestamp.                 |

---

### 3. **Articles**
**Purpose**: Stores and manages content like blog posts or news.

| Column Name       | Data Type      | Description                             |
|-------------------|----------------|-----------------------------------------|
| ArticleID         | UUID           | Primary key.                            |
| Title             | VARCHAR(500)   | Title of the article.                   |
| Slug              | VARCHAR(500)   | URL-friendly title.                     |
| Content           | TEXT           | Main content of the article.            |
| Status            | ENUM           | Draft, Published, Archived.             |
| AuthorID          | UUID           | Foreign key to the `Users` table.       |
| CreatedAt         | TIMESTAMP      | Article creation timestamp.             |
| UpdatedAt         | TIMESTAMP      | Last updated timestamp.                 |
| PublishedAt       | TIMESTAMP      | Publication timestamp.                  |

---

### 4. **Categories**
**Purpose**: Organizes articles into hierarchical categories.

| Column Name       | Data Type      | Description                             |
|-------------------|----------------|-----------------------------------------|
| CategoryID        | UUID           | Primary key.                            |
| Name              | VARCHAR(255)   | Name of the category.                   |
| Slug              | VARCHAR(255)   | URL-friendly name.                      |
| ParentCategoryID  | UUID           | Foreign key to itself for hierarchies.  |
| CreatedAt         | TIMESTAMP      | Category creation timestamp.            |
| UpdatedAt         | TIMESTAMP      | Last updated timestamp.                 |

---

### 5. **Tags**
**Purpose**: Allows flexible tagging of articles and other content.

| Column Name       | Data Type      | Description                             |
|-------------------|----------------|-----------------------------------------|
| TagID             | UUID           | Primary key.                            |
| Name              | VARCHAR(255)   | Name of the tag.                        |
| Slug              | VARCHAR(255)   | URL-friendly tag name.                  |
| CreatedAt         | TIMESTAMP      | Tag creation timestamp.                 |
| UpdatedAt         | TIMESTAMP      | Last updated timestamp.                 |

---

### 6. **Media Library**
**Purpose**: Manages uploaded media files.

| Column Name       | Data Type      | Description                             |
|-------------------|----------------|-----------------------------------------|
| MediaID           | UUID           | Primary key.                            |
| FileName          | VARCHAR(255)   | Name of the file.                       |
| FilePath          | TEXT           | Path to the file location.              |
| FileType          | VARCHAR(50)    | Type of file (image, video, etc.).       |
| FileSize          | INT            | Size of the file in bytes.              |
| UploadedBy        | UUID           | Foreign key to `Users`.                 |
| CreatedAt         | TIMESTAMP      | File upload timestamp.                  |
| UpdatedAt         | TIMESTAMP      | Last updated timestamp.                 |

---

### 7. **Workflows**
**Purpose**: Tracks content statuses and publishing workflows.

| Column Name       | Data Type      | Description                             |
|-------------------|----------------|-----------------------------------------|
| WorkflowID        | UUID           | Primary key.                            |
| ArticleID         | UUID           | Foreign key to `Articles`.              |
| CurrentStatus     | ENUM           | Draft, Review, Published.               |
| AssignedTo        | UUID           | Foreign key to `Users`.                 |
| CreatedAt         | TIMESTAMP      | Workflow creation timestamp.            |
| UpdatedAt         | TIMESTAMP      | Last updated timestamp.                 |

---

### 8. **Audit Logs**
**Purpose**: Tracks changes and actions performed in the system.

| Column Name       | Data Type      | Description                             |
|-------------------|----------------|-----------------------------------------|
| LogID             | UUID           | Primary key.                            |
| UserID            | UUID           | Foreign key to `Users`.                 |
| Action            | TEXT           | Description of the action performed.    |
| EntityType        | VARCHAR(255)   | Type of entity affected (e.g., Article).|
| EntityID          | UUID           | ID of the affected entity.              |
| CreatedAt         | TIMESTAMP      | Timestamp of the action.                |

---

### 9. **Settings**
**Purpose**: Stores global CMS configurations.

| Column Name       | Data Type      | Description                             |
|-------------------|----------------|-----------------------------------------|
| SettingKey        | VARCHAR(255)   | Unique key for the setting.             |
| SettingValue      | TEXT           | Value of the setting.                   |
| CreatedAt         | TIMESTAMP      | Setting creation timestamp.             |
| UpdatedAt         | TIMESTAMP      | Last updated timestamp.                 |

---

### 10. **Menus**
**Purpose**: Manages navigation menus and their items.

| Column Name       | Data Type      | Description                             |
|-------------------|----------------|-----------------------------------------|
| MenuID            | UUID           | Primary key.                            |
| Name              | VARCHAR(255)   | Name of the menu.                       |
| CreatedAt         | TIMESTAMP      | Menu creation timestamp.                |
| UpdatedAt         | TIMESTAMP      | Last updated timestamp.                 |

#### **Menu Items**
| Column Name       | Data Type      | Description                             |
|-------------------|----------------|-----------------------------------------|
| MenuItemID        | UUID           | Primary key.                            |
| MenuID            | UUID           | Foreign key to `Menus`.                 |
| Label             | VARCHAR(255)   | Display name of the menu item.          |
| URL               | TEXT           | URL or internal link.                   |
| ParentMenuItemID  | UUID           | Foreign key to itself for hierarchies.  |
| CreatedAt         | TIMESTAMP      | Menu item creation timestamp.           |
| UpdatedAt         | TIMESTAMP      | Last updated timestamp.                 |

---

## Summary
This schema addresses the current gaps and provides a flexible, scalable foundation for a modern CMS. Key additions include:
- Flexible tagging, workflows, and content relationships.
- A centralized media library with robust metadata.
- Global settings, menus, and audit logs for better management.

Let me know if additional details or further refinements are required.



Certainly! Below is a list of necessary features and components for a modern CMS database that are **missing or not fully covered** in your current schema. These features ensure a CMS can handle common content management needs, scale effectively, and provide flexibility for future enhancements.

---

### **Missing or Insufficiently Covered Features for a CMS Database**

| **Feature/Component**       | **Description**                                                                                         | **Why It's Necessary**                                                                                   |
|------------------------------|---------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------|
| **Content Versioning**       | A system to track changes to content, with rollback functionality (e.g., `VersionHistory` table).      | Essential for collaborative editing and maintaining an audit trail of content changes.                    |
| **Flexible Taxonomy System** | A unified tagging and categorization system to allow flexible grouping of content.                     | Helps organize content beyond rigid category structures (e.g., tags for search and filtering).             |
| **User Profiles**            | Extend user management to include profiles with metadata (e.g., avatars, preferences).                 | Supports personalized experiences for users or administrators.                                            |
| **Media Library**            | A dedicated table for managing media files, including paths, metadata (e.g., size, format, type).      | Improves media organization and supports modern formats and CDN integrations.                             |
| **Page Templates**           | A table to define and manage templates for pages and layouts.                                          | Enables structured content presentation and simplifies custom theming.                                     |
| **Workflow Management**      | Tables to manage content statuses (draft, review, publish), assignees, and deadlines.                  | Necessary for team-based publishing and ensuring content readiness.                                       |
| **Permissions System**       | Role-based access control (RBAC) with permissions for specific actions (e.g., edit, publish, delete).  | Improves security and allows fine-grained control over user capabilities.                                  |
| **Custom Fields**            | A system for admins to define custom fields for content types.                                         | Provides flexibility to extend content types without modifying the schema.                                 |
| **Activity Logs**            | Logs for all user actions, such as logins, content edits, and permission changes.                      | Critical for tracking user activity and debugging issues.                                                  |
| **Menu Management**          | A table to define navigation menus and menu items with hierarchical structures.                        | Allows dynamic, database-driven menus that can be updated via the CMS.                                     |
| **SEO Tools**                | A table for managing metadata (e.g., meta tags, descriptions, keywords, slugs).                        | Improves search engine optimization and makes the site discoverable.                                       |
| **Content Relationships**    | A system for linking content dynamically (e.g., related articles, parent-child relationships).         | Enhances user experience by suggesting related or grouped content.                                         |
| **Global Settings**          | A key-value store for site-wide settings (e.g., site name, language, default theme).                   | Centralizes global configurations that affect the entire CMS.                                              |
| **Audit Trail**              | A record of changes made to the database, including who made changes and when.                        | Ensures accountability and compliance with governance or legal requirements.                               |
| **Multi-language Support**   | A system to manage translations for content, categories, menus, etc.                                   | Makes the CMS viable for international audiences and multi-language content.                               |
| **Content Scheduling**       | A table or column for publishing or unpublishing content at specific times.                           | Automates content updates without manual intervention.                                                     |
| **CDN Integration**          | A way to store external URLs for media served via a CDN.                                               | Improves performance and scalability by offloading static content delivery.                                 |
| **Notifications**            | A table to track system or user-specific notifications (e.g., content approval requests).              | Keeps users informed about important system events or actions required.                                    |
| **API Access Tokens**        | A system for generating and managing tokens for API access.                                            | Enables secure integration with external systems or mobile applications.                                   |
| **Customizable Dashboard**   | Metadata for dashboard widgets or user-specific dashboard preferences.                                | Provides admins with a quick overview tailored to their needs.                                             |

---

### **Summary of Gaps**
From your provided schema:
1. **Insufficient flexibility**: The schema is tied to rigid structures (e.g., hardcoded categories and types).
2. **Lack of modularity**: Missing features like custom fields, flexible menus, or reusable components.
3. **Scalability concerns**: Current tables like `CMSLog` may grow without effective purging or archiving.

---


