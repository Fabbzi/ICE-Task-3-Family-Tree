# Usage Guide - Royal Family Tree Application

## Quick Start

### Option 1: Using Visual Studio
1. Open `RoyalFamilyTree.sln` in Visual Studio
2. Press F5 or click "Start" to run the application
3. The family tree will be displayed automatically

### Option 2: Using Command Line
```bash
# Navigate to the project directory
cd RoyalFamilyTree

# Build the project
dotnet build

# Run the application
dotnet run
```

### Option 3: Running the Executable
```bash
# Navigate to the build output directory
cd RoyalFamilyTree/bin/Debug/net8.0-windows

# Run the executable
./RoyalFamilyTree.exe
```

## Understanding the Display

### Window Layout

```
┌────────────────────────────────────────────┐
│        THE HOUSE OF WINDSOR               │ ← Header
│     Royal Family Tree Visualization       │
├────────────────────────────────────────────┤
│                                            │
│  ┌───────────────────────┐                │
│  │ Queen Elizabeth II    │ ← Member Card  │
│  │ Born: April 21, 1926  │                │ ← Scrollable
│  │ (Deceased)            │                │   Content Area
│  └───────────────────────┘                │
│                                            │
│    ┌───────────────────────┐              │
│    │ King Charles III      │              │
│    │ Born: Nov 14, 1948    │              │
│    │ (Age: 76)             │              │
│    └───────────────────────┘              │
│                                            │
├────────────────────────────────────────────┤
│ Legend: [Alive] = Green | [Deceased] = Gray│ ← Footer
└────────────────────────────────────────────┘
```

### Color Coding

| Color | Meaning | Example |
|-------|---------|---------|
| 🟢 Green | Living family member | King Charles III |
| 🔵 Blue | Living spouse | Catherine, Princess of Wales |
| ⚫ Gray | Deceased member | Queen Elizabeth II |

### Information Displayed

Each family member card shows:
1. **Name**: Full name with royal titles
2. **Date of Birth**: In format "Month Day, Year"
3. **Status**: 
   - For living members: Current age
   - For deceased members: "(Deceased)"

### Family Structure

The indentation shows the generational hierarchy:
- No indent: Queen Elizabeth II (root)
- 1 indent: Her children (Charles, Anne, Andrew, Edward)
- 2 indents: Her grandchildren (William, Harry, etc.)
- 3 indents: Her great-grandchildren (George, Charlotte, Louis, etc.)

## Navigation

### Scrolling
- Use the **mouse wheel** to scroll up/down
- Use the **scroll bar** on the right side
- For horizontal scrolling (if needed), use the bottom scroll bar

### Window Controls
- **Maximize**: Click the maximize button to use full screen
- **Resize**: Drag window edges to resize
- **Minimize**: Click minimize to hide the window

## Family Members Included

The application displays the following members:

### Generation 1 (Root)
- Queen Elizabeth II (1926-2022) †
- Prince Philip, Duke of Edinburgh (1921-2021) †

### Generation 2 (Children)
- King Charles III (1948)
- Princess Anne (1950)
- Prince Andrew (1960)
- Prince Edward (1964)

### Generation 3 (Grandchildren)
- Prince William (1982)
- Prince Harry (1984)
- Peter Phillips (1977)
- Zara Tindall (1981)
- Princess Beatrice (1988)
- Princess Eugenie (1990)
- Lady Louise Windsor (2003)
- James, Viscount Severn (2007)

### Generation 4 (Great-grandchildren)
- Prince George (2013)
- Princess Charlotte (2015)
- Prince Louis (2018)
- Prince Archie (2019)
- Princess Lilibet (2021)

### Spouses Shown
- Diana, Princess of Wales (1961-1997) †
- Catherine, Princess of Wales (1982)
- Meghan, Duchess of Sussex (1981)

*† = Deceased*

## Tips and Tricks

### For Best Experience
1. **Maximize the window** to see more family members at once
2. **Scroll slowly** to read all the information
3. **Look for indentation** to understand relationships
4. **Note the colors** to quickly identify living vs. deceased members

### Understanding Relationships
- Members at the same indentation level are siblings
- Members with "m." prefix are married to the previous member
- Children are indented one level more than their parents

## Troubleshooting

### Application Won't Start
- **Issue**: "Could not load file or assembly..."
- **Solution**: Ensure .NET 8.0 Runtime is installed
- **Download**: https://dotnet.microsoft.com/download

### Window is Too Small
- **Issue**: Can't see all the content
- **Solution**: 
  1. Maximize the window
  2. Use scroll bars to navigate
  3. Resize the window by dragging edges

### Build Errors
- **Issue**: "error NETSDK1100: To build a project targeting Windows..."
- **Solution**: 
  1. Ensure you're on Windows OS
  2. Add `<EnableWindowsTargeting>true</EnableWindowsTargeting>` to .csproj
  3. Rebuild the project

### Missing Family Members
- **Issue**: Some expected members are not shown
- **Solution**: This is intentional - the tree includes major line members. To add more members, edit `FamilyTreeData.cs`

## Customization

### Adding New Family Members

1. Open `RoyalFamilyTree/FamilyTreeData.cs`
2. Locate the relevant parent member
3. Add a new family member:

```csharp
var newMember = new FamilyMember("Name", new DateTime(year, month, day), true);
parentMember.Children.Add(newMember);
```

4. Rebuild and run the application

### Changing Colors

1. Open `RoyalFamilyTree/MainWindow.xaml.cs`
2. Find the `RenderFamilyMember` method
3. Modify the color values:
   - Living: `Color.FromRgb(46, 204, 113)` (Green)
   - Deceased: `Color.FromRgb(149, 165, 166)` (Gray)
   - Spouse: `Color.FromRgb(52, 152, 219)` (Blue)

### Modifying Layout

1. Open `RoyalFamilyTree/MainWindow.xaml`
2. Edit XAML properties:
   - Window size: `Height="700" Width="1200"`
   - Colors: Modify `Background` properties
   - Fonts: Change `FontSize` properties

## Console Demo

For testing or on non-Windows systems, you can use the console demo:

1. Open `ConsoleDemo.cs`
2. Call `ConsoleDemo.Run()` from a console application
3. View the text-based family tree output

## Support and Feedback

### Getting Help
- Review the **ARCHITECTURE.md** for technical details
- Check the **README.md** for general information
- Read the **FEATURES.md** for implementation details

### Reporting Issues
1. Check if the issue is already documented
2. Verify your .NET version (must be 8.0+)
3. Ensure you're on Windows OS
4. Provide detailed error messages

## License

This is an educational project for demonstrating WPF and C# capabilities.

## Credits

- **Royal Family Data**: Based on publicly available information
- **Design**: Modern flat design principles
- **Technology**: Microsoft .NET and WPF framework
