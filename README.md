# Creating the content for the .md file

env_variables_content = """
# Environment Variables Documentation

This document explains how to configure environment variables for the SauceDemo automation project. These variables are used to manage user credentials securely and are essential for running the tests.

---

## **Environment Variables**

You need to set the following environment variables in your system to run the project:

### **User Credentials**

| Variable Name             | Description                              | Example Value             |
|---------------------------|------------------------------------------|---------------------------|
| `USER_STANDARD`           | Username for Standard User.              | `standard_user`           |
| `USER_LOCKED_OUT`         | Username for Locked Out User.            | `locked_out_user`         |
| `USER_PROBLEM`            | Username for Problem User.               | `problem_user`            |
| `USER_PERFORMANCE`        | Username for Performance Glitch User.    | `performance_glitch_user` |
| `USER_ERROR`              | Username for Error User.                 | `error_user`              |
| `USER_VISUAL`             | Username for Visual User.                | `visual_user`             |

#### **Shared Password**

| Variable Name    | Description                      | Example Value    |
|------------------|----------------------------------|------------------|
| `PASSWORD`       | Password for all user accounts. | `secret_sauce`   |

---

## **Setting Environment Variables**

### **1. Windows**

#### Using Command Prompt:
1. Open Command Prompt with Administrator privileges.
2. Run the following commands:
   ```bash
   setx USER_STANDARD "standard_user" /M
   setx USER_LOCKED_OUT "locked_out_user" /M
   setx USER_PROBLEM "problem_user" /M
   setx USER_PERFORMANCE "performance_glitch_user" /M
   setx USER_ERROR "error_user" /M
   setx USER_VISUAL "visual_user" /M
   setx PASSWORD "secret_sauce" /M
