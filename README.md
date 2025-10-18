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
- **Search Functionality**: 
  - Search for family members by name (case-insensitive)
  - View succession position in line to throne
  - Highlight found members in the tree
- **Dynamic Member Addition**: Add new family members through the GUI
  - Enter name, date of birth, and status
  - Select parent from existing members
  - Automatically updates tree visualization
- **BFS and DFS Traversal**: 
  - Breadth-First Search for level-order traversal
  - Depth-First Search for lineage-based traversal
  - Used internally for search and succession calculations

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

## How to Use

### Searching for Family Members

1. Enter a name (or part of a name) in the search box
2. Click "Search" to find matching members
3. If multiple matches are found, select the desired member from the list
4. View details including succession position
5. The found member will be highlighted in the tree with a red border and star (⭐)
6. Click "Clear" to reset the view

### Adding New Family Members

1. Click the "+ Add Family Member" button
2. Enter the member's name
3. Select date of birth using the date picker
4. Check/uncheck "Currently Alive" as appropriate
5. Select the parent from the dropdown list
6. Click "Add" to add the member to the tree
7. The tree will automatically refresh with the new member

## Future Enhancements

Potential improvements for the application:
- Filtering by generation or status
- Export to PDF or image
- Interactive tooltips with more detailed information
- Photos of family members
- Edit and delete member functionality
- Save/load family tree data from files
