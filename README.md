TODO App - README
TODO App

A simple and efficient task management application designed to help users organize and prioritize their daily tasks effectively. This application demonstrates the use of the MVVM (Model-View-ViewModel) architecture and modern development practices, implemented in C# with WPF (Windows Presentation Foundation).

Features

    Task Management: Create, update, and delete tasks.
    Categorization: Organize tasks into categories for better management.
    User-Friendly Interface: Clean and responsive UI built using WPF.
    Separation of Concerns: Clear division of logic and presentation layers using the MVVM pattern.
    Reusable Components: Styled and modular XAML components for consistency.

Technologies and Tools Used

    C#: Core programming language for application logic.
    WPF (Windows Presentation Foundation): Framework for building the desktop application interface.
    MVVM Architecture:
        Models: Handle data and business logic.
        ViewModels: Act as the bridge between UI (View) and business logic.
        Views: Define the UI layer using XAML.
    XAML Styles and Resources:
        Centralized styles for consistency across the application.
        Reusable resource dictionaries for maintainable styling.
    Git: Version control system for code management.

Folder Structure

  .
├── Models            # Business and data models
├── ViewModels        # ViewModel layer for binding logic to UI
├── Views             # XAML files for the application interface
├── Resources/Styles  # XAML styles and resource dictionaries
├── App.xaml          # Application-wide resources and settings
├── MainWindow.xaml   # Main application window
└── Tasker.csproj     # Project configuration file

Usage

    Open the application.
    Use the "Add Task" button to create a new task.
    Assign tasks to specific categories.
    Edit or delete tasks as needed.

