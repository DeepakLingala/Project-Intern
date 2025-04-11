# 🎮 Crimson Tactics – Tactical Grid-Based Strategy Game

Welcome to **Crimson Tactics**, a tactical 3D grid-based game developed in Unity. The project demonstrates a full-featured tactical gameplay system including grid generation, pathfinding, and basic enemy AI logic.

---

## 🧩 Key Features

- 🔲 **Dynamic 10x10 Grid System** – Instantiates tile prefabs to build a grid-based world.
- 🖱️ **Mouse Interaction** – Detects tile hover and selection using raycasting.
- 🎨 **Visual Feedback** – Tiles highlight on hover, show movement paths, and update color based on state (default, obstacle, path).
- 🧱 **Obstacle System** – Obstacle prefabs that block player and enemy movement.
- 🧠 **A* Pathfinding Algorithm** – Allows the player to move to target tiles using the shortest walkable path.
- 🤖 **Basic Enemy AI** – Enemies can navigate the grid, follow paths, and track the player.
- 🎮 **Player Control** – Click-based movement using Unity’s physics and coroutines.

---

## 🛠️ Built With

- **Unity Engine (2022.3+)**
- **C#**
- **Unity Editor**

- This Unity project demonstrates a 3D tactical grid-based game developed with C#. It includes a tile-based movement system, pathfinding mechanics, and player interaction on a dynamically generated 10x10 grid.

## 🌟 Features

- 🧱 **10x10 Grid Generation**  
  Procedurally generates a 10x10 tile grid using Unity cubes. Each tile stores its own grid position and obstacle state.

- 🎮 **Player Movement**  
  The player character moves across the grid via mouse input and follows the shortest path using a custom pathfinding algorithm.

- 🚧 **Obstacle Placement**  
  Designated tiles can be set as obstacles that block movement. Obstacle tiles are visually marked in red.

- 🧠 **A* Pathfinding Logic**  
  Efficient pathfinding is implemented to navigate around obstacles, dynamically finding the shortest path from one tile to another.

- 🖱️ **Tile Interaction**  
  Hover detection via raycasting highlights tiles and shows their coordinates. Tiles change color based on their state (default green, red for obstacles).

## 📦 Project Structure

- `GridManager.cs`: Handles generation and data storage for the tile grid.
- `Tile.cs`: Represents individual tile behaviors (coordinates, obstacle status, color updates).
- `PlayerController.cs`: Handles user input, tile selection, and movement across path.
- `Pathfinding.cs`: Custom implementation of A* algorithm to determine efficient movement paths.

## 🧪 How to Run

1. Clone the repository or download the ZIP.
2. Open the project in Unity.
3. Ensure `tilePrefab` is assigned in `GridManager`.
4. Enter Play Mode and click tiles to move the player.
5. Use the UI to observe tile positions or add obstacles.

## 💡 Notes

- All tiles default to green unless marked as obstacles.
- The project supports basic enemy AI and future enhancements like turn-based mechanics.

- ## 📷 Screenshots
- **Interface**
- ![image](https://github.com/user-attachments/assets/e469fe0f-2d19-42a5-a91b-577e04833b89)

- **Showing the Tile Postion**
- ![image](https://github.com/user-attachments/assets/0ec3adf8-0153-4634-9f34-5bf60be287b5)

- **Tile Postion**
- ![image](https://github.com/user-attachments/assets/996ec2db-d3c4-44ca-803f-1ba12f7b04fc)

- **Pathfinding**
- ![image](https://github.com/user-attachments/assets/06da2ec1-aa58-4fe9-8558-80c2674f3087)

**Thank you for giving me this Oportunity. I build this 3D Grid pathfinding way for my Intern and I try my best one I hope that it desires to you 😊**

