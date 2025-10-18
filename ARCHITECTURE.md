# Royal Family Tree - Architecture Documentation

## Project Overview

This WPF application visualizes The House of Windsor family tree with a hierarchical display showing relationships, dates of birth, and current status of family members.

## Architecture

### 1. Data Model (`FamilyMember.cs`)

The core data structure representing each person in the family tree:

```csharp
public class FamilyMember
{
    - Name: string
    - DateOfBirth: DateTime
    - IsAlive: bool
    - Spouse: FamilyMember?
    - Children: List<FamilyMember>
    
    + GetAge(): int
    + GetStatusText(): string
}
```

**Key Features:**
- Stores all essential information about each family member
- Maintains bidirectional spouse relationships
- Maintains parent-child relationships through the Children list
- Calculates age for living members
- Provides formatted status text

### 2. Data Layer (`FamilyTreeData.cs`)

Static class providing the Windsor family tree data:

```csharp
public static class FamilyTreeData
{
    + GetWindsorFamilyTree(): FamilyMember
}
```

**Family Structure:**
```
Queen Elizabeth II (1926-2022) + Prince Philip (1921-2021)
├── King Charles III (1948) + Diana (1961-1997)
│   ├── Prince William (1982) + Catherine (1982)
│   │   ├── Prince George (2013)
│   │   ├── Princess Charlotte (2015)
│   │   └── Prince Louis (2018)
│   └── Prince Harry (1984) + Meghan (1981)
│       ├── Prince Archie (2019)
│       └── Princess Lilibet (2021)
├── Princess Anne (1950)
│   ├── Peter Phillips (1977)
│   └── Zara Tindall (1981)
├── Prince Andrew (1960)
│   ├── Princess Beatrice (1988)
│   └── Princess Eugenie (1990)
└── Prince Edward (1964)
    ├── Lady Louise Windsor (2003)
    └── James, Viscount Severn (2007)
```

### 3. Presentation Layer

#### MainWindow.xaml
- Defines the UI layout
- Header with title
- ScrollViewer for the tree content
- Footer with legend

#### MainWindow.xaml.cs
- `LoadFamilyTree()`: Initializes the tree from data
- `RenderFamilyMember()`: Recursively renders family members
- `AlreadyRendered()`: Prevents duplicate spouse rendering

**Visual Design:**
- **Green boxes**: Living family members
- **Blue boxes**: Living spouses
- **Gray boxes**: Deceased members
- Indentation indicates generational hierarchy
- Each box shows: Name, Date of Birth, Status

### 4. Application Entry Point

#### App.xaml & App.xaml.cs
- Standard WPF application entry point
- Sets MainWindow as the startup window

## Design Patterns Used

1. **Static Factory Pattern**: `FamilyTreeData.GetWindsorFamilyTree()` creates the tree structure
2. **Composite Pattern**: `FamilyMember` with Children list forms a tree structure
3. **MVVM-Light**: Code-behind handles UI logic with minimal business logic

## Color Scheme

- **Primary Background**: `#ECF0F1` (Light gray)
- **Header**: `#2C3E50` (Dark blue-gray)
- **Footer**: `#34495E` (Medium blue-gray)
- **Living Member**: `#2ECC71` (Green)
- **Living Spouse**: `#3498DB` (Blue)
- **Deceased Member**: `#95A5A6` (Gray)
- **Border**: `#34495E` (Medium blue-gray)

## Future Enhancements

1. **Data Persistence**: Load family data from JSON/XML files
2. **Interactive Features**: Click to expand/collapse branches
3. **Search Functionality**: Find family members by name
4. **Export Options**: PDF, PNG, or printable format
5. **Photo Support**: Display photos of family members
6. **Timeline View**: Show events chronologically
7. **Statistics**: Age distribution, generation counts
8. **Relationship Calculator**: Show how two members are related

## Building and Running

### Prerequisites
- .NET 8.0 SDK or later
- Windows OS (WPF is Windows-only)

### Build
```bash
cd RoyalFamilyTree
dotnet build
```

### Run
```bash
cd RoyalFamilyTree
dotnet run
```

Or open in Visual Studio and press F5.

## Testing

While the GUI requires Windows to run, the data model and logic can be tested independently:

1. The `ConsoleDemo.cs` class provides a console-based visualization
2. Unit tests can be added for `FamilyMember` methods
3. Integration tests can verify the complete tree structure

## Security

- No external data sources or network calls
- No user input processing
- Static, read-only data
- No authentication or authorization needed

## Performance

- Tree rendering is O(n) where n = number of family members
- Current tree has ~26 members, renders instantly
- Memory usage is minimal
- No background processing or threading needed
