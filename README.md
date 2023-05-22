# About

FlopsNewProjectTemplate is used for any new WPF Windows applications. It gives you a **simple** starting setup with dependency injections, folder arhitecture, dialog, snackbar and infobox service.
The project is made for personal needs and its free to use.

## System
.Net Framework 4.7.2 <br>
.Net Core 6

## Instalation

###### Project template
You can use the project by downloading the Release (.zip file) and saving it as is in your Visual Studio Templates folder.<br>
Usually its located:
>%USERPROFILE%\Documents\Visual Studio 2022\Templates\ProjectTemplates
The project will then be available in the VisualStudio Wizard when starting a new project.

###### Clone

...or you can just clone the source code and go from there.

## Usage 
The project is made using MVVVM pattern with dependency injection. See App.xaml.cs for the DI part.<br>
The settings view contains examples of available services and how they are used.

### Configuration
The app configuration is located inside App.config.json folder. <br>
The Slowcheetah transformation on build is used for config file switch depending on the configuration.
Inside DI the config.json is mapped to a AppConfiguration class which is then used as a singleton trought the application for geting the configuration values.

### Adding new views
1. New views are added to Views folder, ViewModel folder and registered with Dependency injection in App.xaml.cs. <br>
2. Each viewmodel must implement **INavigationable** interface for it to be recognized by the navigation service.<br>
3. New menu button for the navigation is then added inside Controls/NavigationMenu.xaml starting on the line 48.
4. Your new view is done.

# App looks

Home View-starting page <br>
![HomeView](/FlopsNewProjectTemplate/Assets/HomeView.png)

Settings view with examples
![SettingsView](/FlopsNewProjectTemplate/Assets/SettingsView.png) <br>
![SettingsControlView](/FlopsNewProjectTemplate/Assets/SettingsControls.png)


