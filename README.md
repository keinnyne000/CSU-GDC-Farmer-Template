# CSU Game Developer's Club Farmer Template

This is a Unity 6000.0.37f1 game template file designed for use in CSU Game Developer's Club game jams, though feel free to use it no matter whenever or whoever you are! 

The template will be most useful for new or busy Unity developers but ideas can be applied universally. 

A major benefit of using this template for Game Developer's Club members is that you can always ask me questions about this in the discord (@KeinNyne).


## Features:
The template is inspired by popular indie game Stardew Valley and includes the following Features.

- Well commented code, explaining behavior
- WASD 2d character controller
- Inventory and hotbar system
- Game state management system
- Item use/behavior
- Saving and loading
- Placeholder sprites with animations (check attributions)


## Unity 6 Template Setup Guide

### Prerequisites
Make sure you have the following installed:
- [GitHub Desktop](https://desktop.github.com/)
- [GitHub Account](https://github.com/)
- [Unity Hub](https://unity.com/download)
- [Unity 6.x](https://unity.com/releases) (Can be installed through Unity Hub)

### Beginner-Friendly Setup (Using GitHub Desktop)
#### 1. Fork the Repository
1. Go to the [GitHub repository](https://github.com/keinnyne000/CSU-GDC-Farmer-Template).
2. Click the `Fork` button in the top-right corner to create a copy of the repository in your GitHub account.

#### 2. Clone the Repository with GitHub Desktop
1. Open [GitHub Desktop](https://desktop.github.com/).
2. Click `File > Clone repository`.
3. Select `URL` and paste your forked repository link (e.g., `https://github.com/keinnyne000/CSU-GDC-Farmer-Template.git`).
4. Choose a local folder to store the project and click `Clone`.
5. Once cloning is complete, open the folder in Explorer/Finder.

#### 3. Open the Project in Unity
1. Open Unity Hub.
2. Click `Open` and navigate to the cloned repository folder.
3. Select the project and click `Open`.
4. If prompted, install the required Unity version.

---

### Advanced Setup (Using Git CLI)

#### 1. Fork the Repository
1. Go to the [GitHub repository](https://github.com/keinnyne000/CSU-GDC-Farmer-Template).
2. Click the `Fork` button in the top-right corner to create a copy of the repository in your GitHub account.

#### 2. Clone Your Forked Repository
1. Open a terminal or Git Bash.
2. Navigate to the directory where you want to store the project:
   ```sh
   cd path/to/your/directory
   ```
3. Clone your fork using the following command:
   ```sh
   git clone https://github.com/keinnyne000/CSU-GDC-Farmer-Template.git
   ```
4. Move into the project folder:
   ```sh
   cd YOUR_REPOSITORY
   ```

#### 3. Set Up Git Remotes (Optional but Recommended)
1. Add the original repository as an upstream remote:
   ```sh
   git remote add upstream https://github.com/ORIGINAL_OWNER/YOUR_REPOSITORY.git
   ```
2. Verify the remotes:
   ```sh
   git remote -v
   ```
3. To sync your fork with the latest changes from the original repository:
   ```sh
   git fetch upstream
   git merge upstream/main
   ```

#### 4. Commit and Push Changes
1. Add new changes:
   ```sh
   git add .
   ```
2. Commit changes with a message:
   ```sh
   git commit -m "Describe your changes here"
   ```
3. Push changes to your fork:
   ```sh
   git push origin main
   ```

#### 5. Creating a Pull Request (Optional)
1. Go to your forked repository on GitHub.
2. Click `Compare & pull request`.
3. Add a meaningful title and description.
4. Click `Create pull request`.

You're all set! 🎉 Happy coding!

# Attributions:
- Placeholder Tile Set Credit: Michele "Buch" Bucelli, https://opengameart.org/content/outdoor-tiles-again
- Player Sprite & Animations: emanuelledev, https://emanuelledev.itch.io/farm-rpg



