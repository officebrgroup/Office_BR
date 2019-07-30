I actually need to do this readme because i am going to forget myself. 10/10 gr8 banter 

So... this was horribly done, by me.
There are two scenes the UI which is the main menu (the title, loadout and options, you can load in the game using this) and the game which is called "Test"

If you want to test it out then download everything...

Umm... start the project.
Open both scenes, (drag them to the Hierarchy)
Go to File -> Build Settings (Ctrl + Shift + B) Assign both of them into the 'Scenes In Build' and make UI have an index of 0 and the game 1.

Currently a lot of the variables have not been assigned
So lets go through everything...

(Ignore Minimap Camera, just delete it)
Player -> Player Script
Speed: Any Float
Game Camera: Camera (Game Object from Hierarchy)

Delete the Canvas as it is for the minimap, but DAVID doesn't want one.

The targets are green boxes
Targets -> Health (Script)
Health: Any Float
Death Effect: None

Assets/Resources/AK47
A lot of these are prefabs from other assets
Bullet Type: 7.62_Bullet (Another Assest Pack)
GunTip: Tip (Children)
ROF: Any Float (600)
Flash: Flash(1) (Children, there are two flashes assign the parent so both of them will work)
Max Ammo: Any Float (20)
Reload Time: 2
Clip: Magazin (Children)
Chamber Time: Any Float (1)

For Barret
Just repeat the ak process, but change
Bullet Type: .50 Cal (Another Asset Pack)




For UI
Everything should work
