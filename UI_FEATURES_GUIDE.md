# UI Features Guide - Royal Family Tree

This guide demonstrates the user interface features of the Royal Family Tree application.

## Main Window Layout

```
┌────────────────────────────────────────────────────────────────────┐
│  Royal Family Tree - The House of Windsor                  [_][□][X]│
├────────────────────────────────────────────────────────────────────┤
│                                                                     │
│  ┌─────────────────────────────────────────────────────────────┐  │
│  │           THE HOUSE OF WINDSOR                              │  │
│  │        Royal Family Tree Visualization                      │  │
│  └─────────────────────────────────────────────────────────────┘  │
│                                                                     │
│  ┌─────────────────────────────────────────────────────────────┐  │
│  │ Search: [____________] [Search] [Clear]  [+ Add Member]     │  │
│  └─────────────────────────────────────────────────────────────┘  │
│                                                                     │
│  ┌─────────────────────────────────────────────────────────────┐↑ │
│  │                                                              │█ │
│  │  ╔═══════════════════════════════════════════════╗          ││ │
│  │  ║ Queen Elizabeth II                            ║  GRAY    ││ │
│  │  ║ Born: April 21, 1926                          ║          ││ │
│  │  ║ (Deceased)                                    ║          ││ │
│  │  ╚═══════════════════════════════════════════════╝          ││ │
│  │                                                              ││ │
│  │  ╔═══════════════════════════════════════════════╗          ││ │
│  │  ║ m. Prince Philip, Duke of Edinburgh           ║  BLUE    ││ │
│  │  ║ Born: June 10, 1921                           ║          ││ │
│  │  ║ (Deceased)                                    ║          │█ │
│  │  ╚═══════════════════════════════════════════════╝          ││ │
│  │                                                              ││ │
│  │      ╔═══════════════════════════════════════════╗          ││ │
│  │      ║ King Charles III                          ║  GREEN   ││ │
│  │      ║ Born: November 14, 1948                   ║          ││ │
│  │      ║ (Age: 76)                                 ║          ││ │
│  │      ╚═══════════════════════════════════════════╝          ││ │
│  │                                                              │↓ │
│  └─────────────────────────────────────────────────────────────┘  │
│  ←═══════════════════════════════════════════════════════════════→ │
│                                                                     │
│  ┌─────────────────────────────────────────────────────────────┐  │
│  │ Legend: [Alive] = Green  [Deceased] = Gray                  │  │
│  └─────────────────────────────────────────────────────────────┘  │
└────────────────────────────────────────────────────────────────────┘
```

## Feature 1: Search Functionality

### Search Box Interface

```
┌────────────────────────────────────────────────────────────┐
│ Search: [William___________] [Search] [Clear]             │
└────────────────────────────────────────────────────────────┘
```

**How to Use**:
1. Type a name (or part of a name) in the search box
2. Click the "Search" button
3. Results will be displayed

### Single Search Result

When one member matches your search:

```
┌─────────────────────────────────────────────────┐
│  Family Member Details              [X]         │
├─────────────────────────────────────────────────┤
│                                                  │
│  Name: Prince William                           │
│  Date of Birth: June 21, 1982                   │
│  Status: (Age: 43)                              │
│  Position in line to throne: #1                 │
│                                                  │
│  Spouse: Catherine, Princess of Wales           │
│  Children: 3                                    │
│                                                  │
│                    [ OK ]                        │
└─────────────────────────────────────────────────┘
```

**After clicking OK**, the member is highlighted in the tree:

```
╔══════════════════════════════════════════════════╗  ← RED BORDER
║ Prince William ⭐                                 ║     (4px thick)
║ Born: June 21, 1982                              ║
║ (Age: 43)                                        ║
╚══════════════════════════════════════════════════╝
```

### Multiple Search Results

When multiple members match your search (e.g., searching "Princess"):

```
┌─────────────────────────────────────────────────┐
│  Multiple Results Found             [X]         │
├─────────────────────────────────────────────────┤
│                                                  │
│  Found 5 members:                               │
│                                                  │
│  ┌───────────────────────────────────────────┐ │
│  │ Princess Anne - Born 1950             ▼   │ │
│  │ Princess Charlotte - Born 2015            │ │
│  │ Princess Lilibet - Born 2021              │ │
│  │ Princess Beatrice - Born 1988             │ │
│  │ Princess Eugenie - Born 1990              │ │
│  └───────────────────────────────────────────┘ │
│                                                  │
│              [ View Details ]                   │
│                                                  │
└─────────────────────────────────────────────────┘
```

**Select a member** and click "View Details" to see their information.

### No Search Results

When no members match your search:

```
┌─────────────────────────────────────────────────┐
│  Search                             [X]         │
├─────────────────────────────────────────────────┤
│                                                  │
│  No family members found matching               │
│  'Napoleon'.                                    │
│                                                  │
│                    [ OK ]                        │
└─────────────────────────────────────────────────┘
```

## Feature 2: Add Family Member

### Add Member Button

```
┌────────────────────────────────────────────────────────────┐
│                                     [+ Add Family Member]  │
└────────────────────────────────────────────────────────────┘
```

Click this button to open the add member dialog.

### Add Member Dialog

```
┌─────────────────────────────────────────────────┐
│  Add Family Member                  [X]         │
├─────────────────────────────────────────────────┤
│                                                  │
│  Name:                                          │
│  [___________________________________________]  │
│                                                  │
│  Date of Birth:                                 │
│  [📅 01/15/2024 ▼]                              │
│                                                  │
│  [✓] Currently Alive                            │
│                                                  │
│  Select Parent:                                 │
│  [Prince William ▼]                             │
│  │ Queen Elizabeth II                           │
│  │ King Charles III                             │
│  │ Prince William                  ◄─ Selected  │
│  │ Prince Harry                                 │
│  │ Princess Anne                                │
│  │ ...                                          │
│  └─                                              │
│                                                  │
│          [ Add ]      [ Cancel ]                │
│                                                  │
└─────────────────────────────────────────────────┘
```

**Steps**:
1. Enter the member's name
2. Select date of birth using date picker
3. Check/uncheck "Currently Alive"
4. Select parent from dropdown
5. Click "Add" to add member or "Cancel" to abort

### After Adding a Member

Success message:

```
┌─────────────────────────────────────────────────┐
│  Success                            [X]         │
├─────────────────────────────────────────────────┤
│                                                  │
│  New Child has been added to the                │
│  family tree!                                   │
│                                                  │
│                    [ OK ]                        │
└─────────────────────────────────────────────────┘
```

The tree automatically refreshes and shows the new member:

```
    ╔═══════════════════════════════════════════╗
    ║ Prince William                            ║
    ║ Born: June 21, 1982                       ║
    ║ (Age: 43)                                 ║
    ╚═══════════════════════════════════════════╝

        ╔═══════════════════════════════════════╗
        ║ Prince George                         ║
        ║ Born: July 22, 2013                   ║
        ║ (Age: 12)                             ║
        ╚═══════════════════════════════════════╝

        ╔═══════════════════════════════════════╗
        ║ Princess Charlotte                    ║
        ║ Born: May 2, 2015                     ║
        ║ (Age: 10)                             ║
        ╚═══════════════════════════════════════╝

        ╔═══════════════════════════════════════╗
        ║ Prince Louis                          ║
        ║ Born: April 23, 2018                  ║
        ║ (Age: 7)                              ║
        ╚═══════════════════════════════════════╝

        ╔═══════════════════════════════════════╗  ← NEW!
        ║ New Child                             ║
        ║ Born: January 15, 2024                ║
        ║ (Age: 1)                              ║
        ╚═══════════════════════════════════════╝
```

## Feature 3: Tree Visualization

### Color Coding

**Living Members** - Green Background:
```
╔═══════════════════════════════════════════╗
║ King Charles III                          ║  ← #2ECC71 (Green)
║ Born: November 14, 1948                   ║     Bold white text
║ (Age: 76)                                 ║
╚═══════════════════════════════════════════╝
```

**Deceased Members** - Gray Background:
```
╔═══════════════════════════════════════════╗
║ Queen Elizabeth II                        ║  ← #95A5A6 (Gray)
║ Born: April 21, 1926                      ║     Bold white text
║ (Deceased)                                ║
╚═══════════════════════════════════════════╝
```

**Spouses** - Blue Background:
```
╔═══════════════════════════════════════════╗
║ m. Catherine, Princess of Wales           ║  ← #3498DB (Blue)
║ Born: January 9, 1982                     ║     "m." = married to
║ (Age: 43)                                 ║     SemiBold white text
╚═══════════════════════════════════════════╝
```

**Highlighted Member** - Red Border:
```
╔═══════════════════════════════════════════╗  ← #E74C3C (Red border)
║ Prince William ⭐                          ║     4px thick
║ Born: June 21, 1982                       ║     Star symbol
║ (Age: 43)                                 ║
╚═══════════════════════════════════════════╝
```

### Hierarchical Layout

Indentation shows generations:

```
Generation 1 (0px indent):
╔═══════════════════════════════╗
║ Queen Elizabeth II            ║
╚═══════════════════════════════╝

    Generation 2 (30px indent):
    ╔═══════════════════════════╗
    ║ King Charles III          ║
    ╚═══════════════════════════╝

        Generation 3 (60px indent):
        ╔═══════════════════════╗
        ║ Prince William        ║
        ╚═══════════════════════╝

            Generation 4 (90px):
            ╔═══════════════════╗
            ║ Prince George     ║
            ╚═══════════════════╝
```

## Feature 4: Scrolling

### Vertical Scrolling

When content exceeds window height:

```
┌─────────────────────────────────────┐↑
│  ╔════════════════════════════════╗ │█  ← Scroll bar
│  ║ Queen Elizabeth II             ║ │█     appears
│  ╚════════════════════════════════╝ │█
│                                     │█
│  ╔════════════════════════════════╗ │█
│  ║ King Charles III               ║ │█
│  ╚════════════════════════════════╝ │█
│                                     │█
│  ╔════════════════════════════════╗ │↓
│  ║ Prince William                 ║ │
└─────────────────────────────────────┘
```

**How to scroll**:
- Mouse wheel
- Scroll bar on right side
- Click and drag scroll bar

### Horizontal Scrolling

When member names are very long:

```
←═══════════════════════════════════════════════════════════════→
       ▲                                                    ▲
       └─ Left scroll                                      └─ Right scroll
```

## Feature 5: Color Legend

Located at the bottom of the window:

```
┌────────────────────────────────────────────────────────────┐
│ Legend: [Alive] = Green  [Deceased] = Gray                 │
└────────────────────────────────────────────────────────────┘
```

Visual representation:

```
Legend:  ┌──────┐     ┌──────────┐
         │Alive │  =  │  Green   │
         └──────┘     └──────────┘
                      #2ECC71

         ┌──────────┐     ┌──────────┐
         │Deceased  │  =  │   Gray   │
         └──────────┘     └──────────┘
                          #95A5A6
```

## Feature 6: Window Controls

### Resize Window

```
┌────────────────────────────┐
│                            │
│                            │  ← Drag corner
│                            │     to resize
│                            │
└────────────────────────────┘
```

### Maximize Window

```
[_][□][X]
    ↑
    Click to maximize (full screen)
```

### Minimize Window

```
[_][□][X]
 ↑
 Click to minimize (to taskbar)
```

### Close Window

```
[_][□][X]
      ↑
      Click to close application
```

## Feature 7: Keyboard Navigation

### Tab Navigation (Standard Windows)

- **Tab**: Move to next control
- **Shift+Tab**: Move to previous control
- **Enter**: Activate selected button
- **Esc**: Close dialog

### Search Box Shortcuts

- **Type and Enter**: Same as clicking Search button
- **Esc in search box**: Clear search box

## Quick Reference

### Button Functions

| Button | Function |
|--------|----------|
| **Search** | Find members by name |
| **Clear** | Reset search and view |
| **+ Add Family Member** | Open add member dialog |
| **View Details** | Show details of selected member |
| **Add** | Confirm adding new member |
| **Cancel** | Close dialog without saving |
| **OK** | Close message box |

### Color Code Reference

| Color | Meaning | RGB |
|-------|---------|-----|
| 🟢 Green | Living member | #2ECC71 |
| 🔵 Blue | Living spouse | #3498DB |
| ⚫ Gray | Deceased member | #95A5A6 |
| 🔴 Red Border | Search highlight | #E74C3C |

### Information Display

Each family member card shows:
1. **Name** (Bold, white text)
2. **Date of Birth** (Format: Month Day, Year)
3. **Status** (Age for living, "Deceased" for deceased)

Spouse cards additionally show:
- **"m."** prefix indicating marriage

Highlighted members show:
- **⭐** star symbol after name
- **Red border** (4px thick)

## Tips for Best Experience

1. **Search**: Use partial names for faster searching (e.g., "Char" for Charles/Charlotte)
2. **Clear**: Always click "Clear" before new search for best results
3. **Scroll**: Use mouse wheel for smooth scrolling
4. **Maximize**: Maximize window to see more family members at once
5. **Multiple Results**: Take time to select correct member from list

## Common Workflows

### Finding a Specific Member

1. Enter name in search box
2. Click "Search"
3. If multiple results, select from list
4. View details including succession position
5. Click "OK" to see highlighted in tree
6. Click "Clear" to reset

### Adding a New Member

1. Click "+ Add Family Member"
2. Fill in all fields
3. Select correct parent
4. Click "Add"
5. See confirmation message
6. View new member in tree

### Exploring the Family Tree

1. Launch application
2. Observe Queen Elizabeth II at top
3. Scroll down to see children
4. Notice indentation for generations
5. Use color coding to identify status
6. Search for specific members of interest

## Accessibility Features

- **High Contrast Colors**: Easy to distinguish status
- **Clear Text Hierarchy**: Bold names, regular details
- **Visual Indicators**: Colors, borders, symbols
- **Scrollable Interface**: Accessible for large trees
- **Dialog-Based Interactions**: Clear, focused tasks

---

**Note**: This guide describes the UI as it appears when running on Windows with .NET 8.0 and WPF.
