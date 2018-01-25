# Overview
This budgeting web app is an online tool designed to help users create and manage their budgets on a monthly basis.

# Minimum Goals/Core Features
**This section describes the bare minimum features we intend to implement for a functioning budget web app.**

# Desired Goals/Features
**This section describes features that we desire to implement but are not core to the budget web app.**

# Page Layout Specifications
**This section describes what functions the specified pages are to contain. Their location within the page is not final.**

* Home Page
  * Not Logged In
  * Logged In
* Selected Monthly Budget Sheet
* Login/Account Creation Page
* Password Reset Page
* About Page
* Contact Page

# Interface Specifications
**This section describes the name and function of interface buttons.**

* Home
* About
* Contact
* Tools

* Logout
* Login
* Create Account
* Reset Password

* Continue Where You Left Off
* Create New Budget Sheet
* Budget Sheet List

* Previous Month
* Next Month
* Create New Main Category
* Create New Sub Category
* Create New Expense
* Edit Main Category

# Pop-up Window Specifications
**This section describes the kinds of pop-up windows we expect to implement, when they pop up, their purpose, their features, and their functions.**

# Database Schema
| Users          | Data Type | Key |       
| -------------- | --------- | --- |
| ID | Int | PK |
| Email | String | |
| Password | String **_Hashed_** | |
| DateCreated | Date | | 
| BudgetCount | Int | |

| Budget         | Data Type | Key |
| -------------- | --------- | --- |
| BudgetID | Int | PK |
| UserID | String | FK |
| DateCreated | Date | |
| BudgetMonth | Date | |

| MainCategory          | Data Type | Key |
| --------------------- | -------- | --- |
| ID | Int | PK | 
| BudgetID | Int | FK |
| Name | String | |
| Allotment | Money | |
| Actual | Money | |

| SubCategory          | Data Type | Key |
| -------------------- | --------- | --- |
| ID | Int | PK | 
| MainCategoryID | Int | FK |
| Name | String | |
| Allotment | Money | |
| Actual | Money | |

| Expense          | Data Type | Key |
| ---------------- | --------- | --- |
| ID | Int | PK | 
| MainCategoryID | Nullable Int | FK |
| SubCategoryID | Nullable Int | FK |
| Name | String | |
| Cost | Money | |
| Description | String | |


