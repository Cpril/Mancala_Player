# Mancala Player
Mancala is traditionally a two-player turn-based strategy board game, played with small stones. 
Each player owns the 6 small holes on their side (bottom or top), and there are 4 stones in each of the 6 pits at the start of the game. Additionally, each player has a store, in which the stones will count toward score.
![image](https://github.com/user-attachments/assets/80ccef14-7089-4066-96ce-336e05847607)
Please Refer to [this document]([url](https://www.scholastic.com/content/dam/teachers/blogs/alycia-zimmerman/migrated-files/mancala_rules.pdf)) to Mancala game rules. 

This project creates a *symbolic AI program* that plays Mancala game through *staged Depth First Search* through *minimax* and contains algorithms to calculate best choice for each turn, and give result within 4 second time frame. It also utilizes *Alpha-beta prunning* for additional proficiency. 
**Table of Content**
- KalaMatch: Run this file to play. (can change the players in this file)
- board.cs: the implementation of the board and rules.
- Player.cs: outlines basic functions and structures of the program.
- HumanPlayer: implementation for human players, if runned with KalaMatch, it allows user imput to play the mancala game.
- BonzoPlayer.cs: A player whose evaluate function depends on whether it can take double turns. In other word, a game player with very basic algorithm
- CostumePlayer: 
**Sample Run:**
This sample run is my player called jxcplayer2 playing against Bonzo Player. Since the player going first will have an advantage, the game is played two times such that each player will get a chance to go first. Overall match result is a sum of the player's score over two games.
Game 1 first a few turns: 
![image](https://github.com/user-attachments/assets/768e4f83-b8e8-42c1-a8ae-63baeae7900a)

Game 1 end turns and results: 
![image](https://github.com/user-attachments/assets/30a66e00-d176-472c-b2ec-e6cc25c6c6b4)

Game 2 first a few turns:
![image](https://github.com/user-attachments/assets/8db47068-acb4-43d2-9bb2-fc615fa558dc)

Game 2 end turns and results: 
![image](https://github.com/user-attachments/assets/d65e6033-fe58-478b-8baa-0fda912b058a)

Overall Match Results: 
![image](https://github.com/user-attachments/assets/9ad23745-ae21-43e0-9c7b-c50c3c70a5a2)
