# JK4Life
#### A launcher and patcher for Jedi Knight / Mysteries of the Sith

In it's current state this is a very barebones launcher for Jedi Knight and Mysteries of the Sith, but I wanted to put it out anyway just so people could get access to the assembly patches that you can do with this. There's a lot more to be added, so stay tuned for that!

Right now all it does is launching mods and doing assembly patches, but I have a lot more planned. For now I'll keep it somewhat mysterious, but trust me it'll be super cool ;)


---

## Near future

Mostly I'll just be planning the future UI, so I'm a bit limited in the things I can do at the moment. Pretty much just cleanup and stuff I know I can easily implement later on.

* Clean up Launch()
  * Launch from original file if no assembly patch is applied
  * Split the patching stuff to seperate class

* Mods
  * Drag & drop install
  * Make it possible to recursively check through mod folders; need to decide on if I want to use tree view
  * Put a FS watcher on the mod folders and automatically refresh on changes

* Maybe have more indicative names for UI elements? Might not be worth if I'm scrapping it all later anyway
