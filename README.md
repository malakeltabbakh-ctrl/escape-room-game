# Escape Room Game — Unity Project

A first-person 3D escape room game built in Unity. The player must solve a series of puzzles across multiple levels before the timer runs out in order to escape.

---

## Overview

The game places the player inside a sci-fi styled environment and challenges them to interact with objects, solve puzzles, and find the correct codes to unlock doors and progress to the next level. A countdown timer adds pressure — run out of time and it's game over.

---

## Scenes

| Scene | Description |
|---|---|
| `MainMenu` | Title screen with Play and Quit buttons |
| `level1` | First puzzle level |
| `level2` | Second puzzle level |
| `level3` | Third puzzle level |

Levels load sequentially. Completing a level triggers the exit door, which loads the next scene. After the final level, the game loops back to the main menu.

---

## Gameplay & Mechanics

### Controls

| Action | Input |
|---|---|
| Move | WASD |
| Look | Mouse |
| Sprint | Hold Shift |
| Jump | Space |
| Interact | E |
| Pick up object | Left Mouse Button |
| Drop object | Right Mouse Button |

### Core Systems

**Timer**
Each level has a countdown timer displayed on screen. If it reaches zero, the game freezes, a Game Over panel appears, and the player can restart or return to the main menu.

**Interaction**
The player interacts with objects by looking at them and pressing **E**. A prompt appears when an interactable object is within range (raycast-based, ~3 units).

**Hints**
Hint boards are placed in the environment. Approach one and press **E** to toggle the hints panel.

---

## Puzzles

### Color Pad Puzzle
Colored boxes must be picked up and placed on matching colored pads. The colors are randomized each playthrough. All boxes must be on their correct pads to complete the puzzle.

### ATM / PIN Puzzle
An ATM machine displays a UI panel when the player enters its trigger zone. The player must enter the correct 3-digit PIN (default: `357`) to open a connected door.

### Picture Rotation Puzzle
Four image tiles are displayed on a panel. Clicking a tile rotates it 90°. The puzzle is solved when all four tiles are aligned to 0° rotation. Tiles start at a random rotation each time.

### ATM Color Sequence Puzzle
Three colored ATMs (Purple, Orange, Yellow) each cycle through visual states when interacted with. The correct combination of states across all three ATMs triggers the win condition for that puzzle.

### Keypad Puzzle
A numeric keypad is used to enter a code. Correct entry triggers an animation to open a sliding door.

---

## Project Structure

```
Assets/
├── Scenes/               # MainMenu, level1, level2, level3
├── Scripts/              # Core: FirstPersonController, DoorTriggerNextLevel, BasicRigidBodyPush
├── Scripts1/             # GameManagerScript, puzzleManager, TimerScript, MainMenu, ShowHintsOnApproach, ATM
├── Scripts2/             # ColorPadManager, Pad, PickUp, Pickuppable, KeyPad, atm
├── Scripts3/             # ATMSystem, GameControl, TouchRotate, PuzzlePanel
├── Prefabs/              # GameOverCanvas, ExitDoor
├── game enviroment/      # Player prefab, door prefabs, ATM prefabs, environment prefab
├── Sci-Fi Styled Modular Pack/  # Environment models, materials, prefabs
├── CGY_ATM/              # ATM 3D model and textures
├── Keypad/               # Keypad model, scripts, sounds, animations
├── JMO Assets/           # Cartoon FX Remaster (particle effects)
├── LeanTween/            # Tweening library
├── TextMesh Pro/         # UI text rendering
├── InputSystem/          # Starter Assets input actions
├── Mobile/               # Virtual joystick / mobile input support
└── images/               # UI and background images
```

---

## Third-Party Assets & Packages

| Asset | Purpose |
|---|---|
| Unity Starter Assets (First Person) | Player controller & input system |
| TextMesh Pro | UI text rendering |
| LeanTween | Animation tweening |
| JMO Cartoon FX Remaster | Particle effects |
| Sci-Fi Styled Modular Pack | Environment art (walls, floors, doors, furniture) |
| CGY ATM | ATM 3D model |
| Keypad (Asset Store) | Keypad model, scripts, and SFX |

---

## Setup & Installation

1. Open **Unity Hub** and add the project folder.
2. Use **Unity 2021.3 LTS** or later (project uses the Input System package).
3. Make sure the following packages are installed via the Package Manager:
   - Input System
   - TextMesh Pro
   - Cinemachine
4. Open `Assets/Scenes/MainMenu.unity` as the starting scene.
5. Confirm all scenes are added to **Build Settings** in this order:
   - `MainMenu` (index 0)
   - `level1` (index 1)
   - `level2` (index 2)
   - `level3` (index 3)
6. Press **Play** to test in the editor, or go to **File → Build & Run** to build.

---

## Notes

- The timer default is set very short (`5f`) in `TimerScript.cs` — change `currentTime` to your desired value (e.g. `120f` for 2 minutes) before building.
- The ATM PIN is set to `"357"` in `ATMSystem.cs` and can be changed in the Inspector or directly in the script.
- Mobile virtual joystick scripts are included but may require additional setup to use on mobile builds.
