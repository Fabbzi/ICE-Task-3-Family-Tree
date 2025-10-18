# ICE-Task-3-Family-Tree

A dynamic family tree visualization tool for The House of Windsor (Royal Family) built with C# and WPF.

## Features

- **Visual Family Tree**: Displays the Royal Family hierarchy starting from Queen Elizabeth II
- **Member Information**: Shows each family member's:
  - Full name and title
  - Date of birth
  - Current status (Alive with age, or Deceased)
- **Color-Coded Display**:
  - Green: Living members
  - Blue: Living spouses
  - Gray: Deceased members
- **Hierarchical Layout**: Family members are indented to show generational relationships
- **Comprehensive Data**: Includes multiple generations from Queen Elizabeth II to Prince George, Princess Charlotte, and Prince Louis

## Requirements

- .NET 8.0 SDK or later
- Windows operating system (WPF is Windows-only)

## Building the Application

```bash
cd RoyalFamilyTree
dotnet build
```

## Running the Application

```bash
cd RoyalFamilyTree
dotnet run
```

Alternatively, you can open the solution in Visual Studio and run it from there.

## Project Structure

- `FamilyMember.cs` - Data model for individual family members
- `FamilyTreeData.cs` - Static data containing the Windsor family tree
- `MainWindow.xaml` - UI layout for the main window
- `MainWindow.xaml.cs` - Code-behind with tree rendering logic
- `App.xaml` - Application entry point

## Family Members Included

The application includes the following members of the Royal Family:

- Queen Elizabeth II and Prince Philip
- Their children: King Charles III, Princess Anne, Prince Andrew, Prince Edward
- King Charles III's children: Prince William, Prince Harry
- Prince William's children: Prince George, Princess Charlotte, Prince Louis
- Prince Harry's children: Prince Archie, Princess Lilibet
- And many more extended family members

## Future Enhancements

Potential improvements for the application:
- Search functionality
- Filtering by generation or status
- Export to PDF or image
- Interactive tooltips with more detailed information
- Photos of family members
