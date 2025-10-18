# Royal Family Tree - UI Mockup

This document provides a visual representation of what the WPF application looks like when running.

## Application Window

### Window Properties
- **Title**: "Royal Family Tree - The House of Windsor"
- **Size**: 1200px width × 700px height (resizable)
- **Position**: Centered on screen
- **Background**: Light gray (#ECF0F1)

## Layout Structure

```
┌────────────────────────────────────────────────────────────────────────────┐
│                    Royal Family Tree Application                           │
│ File  Edit  View  Help                                              ☐ ☐ ✕ │
├────────────────────────────────────────────────────────────────────────────┤
│                                                                            │
│  ╔══════════════════════════════════════════════════════════════════════╗ │
│  ║            THE HOUSE OF WINDSOR                                      ║ │
│  ║         Royal Family Tree Visualization                              ║ │
│  ╚══════════════════════════════════════════════════════════════════════╝ │
│                                                                            │
│  ┌──────────────────────────────────────────────────────────────────┐ ▲  │
│  │                                                                   │ █  │
│  │  ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓            │ │  │
│  │  ┃ Queen Elizabeth II                               ┃            │ │  │
│  │  ┃ Born: April 21, 1926                             ┃ [GRAY]     │ │  │
│  │  ┃ (Deceased)                                       ┃            │ │  │
│  │  ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛            │ │  │
│  │                                                                   │ │  │
│  │  ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓            │ │  │
│  │  ┃ m. Prince Philip, Duke of Edinburgh              ┃            │ │  │
│  │  ┃ Born: June 10, 1921                              ┃ [BLUE]     │ │  │
│  │  ┃ (Deceased)                                       ┃            │ │  │
│  │  ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛            │ │  │
│  │                                                                   │ │  │
│  │      ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓            │ │  │
│  │      ┃ King Charles III                             ┃            │ │  │
│  │      ┃ Born: November 14, 1948                      ┃ [GREEN]    │ │  │
│  │      ┃ (Age: 76)                                    ┃            │ │  │
│  │      ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛            │ │  │
│  │                                                                   │ │  │
│  │          ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓            │ │  │
│  │          ┃ Prince William                           ┃            │ │  │
│  │          ┃ Born: June 21, 1982                      ┃ [GREEN]    │ │  │
│  │          ┃ (Age: 43)                                ┃            │ █  │
│  │          ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛            │ │  │
│  │                                                                   │ │  │
│  │          ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓            │ │  │
│  │          ┃ m. Catherine, Princess of Wales          ┃            │ │  │
│  │          ┃ Born: January 9, 1982                    ┃ [BLUE]     │ │  │
│  │          ┃ (Age: 43)                                ┃            │ │  │
│  │          ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛            │ │  │
│  │                                                                   │ │  │
│  │              ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓            │ │  │
│  │              ┃ Prince George                        ┃            │ │  │
│  │              ┃ Born: July 22, 2013                  ┃ [GREEN]    │ │  │
│  │              ┃ (Age: 12)                            ┃            │ │  │
│  │              ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛            │ │  │
│  │                                                                   │ ▼  │
│  └──────────────────────────────────────────────────────────────────┘    │
│  ◄═══════════════════════════════════════════════════════════════════►   │
│                                                                            │
│  ╔══════════════════════════════════════════════════════════════════════╗ │
│  ║ Legend: [Alive] = Green  │  [Deceased] = Gray                       ║ │
│  ╚══════════════════════════════════════════════════════════════════════╝ │
└────────────────────────────────────────────────────────────────────────────┘
```

## Color Legend

### Member Status Colors

| Status | Color Code | RGB Values | Visual Example |
|--------|-----------|------------|----------------|
| Living Member | Green | `#2ECC71` (46, 204, 113) | 🟢 |
| Living Spouse | Blue | `#3498DB` (52, 152, 219) | 🔵 |
| Deceased Member | Gray | `#95A5A6` (149, 165, 166) | ⚫ |

### UI Element Colors

| Element | Color Code | RGB Values |
|---------|-----------|------------|
| Header Background | `#2C3E50` | (44, 62, 80) |
| Header Text | White | (255, 255, 255) |
| Footer Background | `#34495E` | (52, 73, 94) |
| Main Background | `#ECF0F1` | (236, 240, 241) |
| Border Color | `#34495E` | (52, 73, 94) |

## Component Details

### Header Section
```
╔════════════════════════════════════════════╗
║        THE HOUSE OF WINDSOR               ║
║     Royal Family Tree Visualization       ║
╚════════════════════════════════════════════╝
```
- **Background**: Dark blue-gray (#2C3E50)
- **Title Font**: 24pt, Bold, White
- **Subtitle Font**: 14pt, Regular, Light gray (#BDC3C7)
- **Padding**: 15px all sides

### Member Card (Living)
```
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃ King Charles III            ┃
┃ Born: November 14, 1948     ┃
┃ (Age: 76)                   ┃
┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
```
- **Background**: Green (#2ECC71)
- **Border**: 2px solid dark gray (#34495E)
- **Corner Radius**: 5px
- **Padding**: 10px
- **Text Color**: White
- **Name Font**: 14pt, Bold
- **Details Font**: 11pt, Regular

### Member Card (Deceased)
```
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃ Queen Elizabeth II          ┃
┃ Born: April 21, 1926        ┃
┃ (Deceased)                  ┃
┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
```
- **Background**: Gray (#95A5A6)
- **Other properties**: Same as living card

### Spouse Card
```
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃ m. Catherine, Princess of Wales   ┃
┃ Born: January 9, 1982             ┃
┃ (Age: 43)                         ┃
┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
```
- **Background**: Blue (#3498DB)
- **Prefix**: "m." indicates married to previous member
- **Other properties**: Same as member cards

### Footer/Legend
```
╔═══════════════════════════════════════════╗
║ Legend: [Alive] = Green | [Deceased] = Gray ║
╚═══════════════════════════════════════════╝
```
- **Background**: Medium blue-gray (#34495E)
- **Text Color**: White
- **Font**: 11pt, Regular
- **Padding**: 10px

## Hierarchy Visualization

The indentation shows generational relationships:

```
[0px indent]    Queen Elizabeth II          ← Generation 1 (Root)
[0px indent]    m. Prince Philip

    [30px]      King Charles III            ← Generation 2 (Children)
    
        [60px]  Prince William              ← Generation 3 (Grandchildren)
        [60px]  m. Catherine
        
            [90px] Prince George            ← Generation 4 (Great-grandchildren)
            [90px] Princess Charlotte
            [90px] Prince Louis
```

Each generation is indented 30 pixels from the previous generation.

## Interaction Features

### Scrolling
- **Vertical Scroll**: Mouse wheel or scroll bar
- **Horizontal Scroll**: If content exceeds window width
- **Smooth Scrolling**: Enabled for better user experience

### Window Controls
- **Resizable**: Drag edges to resize
- **Minimizable**: Standard Windows minimize
- **Maximizable**: Full screen available
- **Closeable**: Standard Windows close

## Responsive Behavior

### Window Resizing
- Content remains properly formatted
- Scroll bars appear when needed
- Cards maintain fixed width
- Hierarchy indentation preserved

### Large Family Trees
- Vertical scrolling for many members
- Maintains performance with 100+ members
- No lag or stuttering

## Accessibility Features

### Visual
- High contrast colors
- Clear text hierarchy
- Readable font sizes
- Distinct color coding

### Navigation
- Standard Windows keyboard shortcuts
- Tab navigation (future enhancement)
- Screen reader support (future enhancement)

## Technical Specifications

### WPF Controls Used
- `Window`: Main application window
- `Grid`: Layout container
- `Border`: Header, footer, member cards
- `StackPanel`: Content organization
- `ScrollViewer`: Scrollable content area
- `TextBlock`: Text display

### Layout System
- Rows: Header (Auto), Content (*), Footer (Auto)
- Content area uses `StackPanel` for vertical stacking
- Recursive rendering for tree structure

## Example Screenshots Descriptions

### Full Window View
Shows the complete application with:
- Header displaying title
- Scrollable content with multiple generations
- Footer with legend
- Professional color scheme

### Zoomed Member Cards
Close-up of individual member cards showing:
- Clear text with good contrast
- Date formatting
- Status indicators
- Rounded corners and borders

### Family Hierarchy
Demonstration of:
- Multi-generational structure
- Proper indentation
- Spouse relationships
- Parent-child connections

---

**Note**: This is a mockup representation. The actual application is built with WPF and runs on Windows systems with .NET 8.0+.
