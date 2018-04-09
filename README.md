# PsJump
Quick commandline navigation by bookmarks (jumps). Supercedes my old [shelljump](https://github.com/kjerk/shelljump) project, as a binary powershell module.
-----

Add to your PS profile with

```Import-Module Path\To\Module\PsJump.psd1```

Inspired by "Quickly navigate your filesystem from the command-line"
http://tinyurl.com/nx6wzvq

Script allows for bookmarking of folders under aliases and the
capability to jump to them, persisting between shell sessions in
a json file.

### Command aliases:
    jumps           | List all existing bookmarks.
    jump (alias)    | Jump to a bookmarked folder.
    mark (alias)    | Bookmarks current directory with a given alias.
    unmark [alias]  | Removes alias.
    loadjumps       | Reloads .json file into shell (if edited or out of date)
    savejumps       | Overwrite .json file with current jumps
    editjumps       | Open .json file in default editor, await exit, and reload.
	
### Underlying functions -> related alias:
    Find-Jump    -> jump
    Add-Jump     -> mark
    Remove-Jump  -> unmark
    Edit-Jumps   -> editjumps
    Get-Jumps    -> jumps
    Import-Jumps -> loadjumps
    Save-Jumps   -> savejumps

### Storage:
  Bookmarks are serialized to a Jumps.json file in the user's Documents directory.
  ~Documents\Jumps.json
  
  Saves are atomic and triggered on add and remove, the last version being saved as Jumps.json.prev.

### Example:
```
	C:\> cd '.\Program Files\Sublime Text 2'
	C:\Program Files\Sublime Text 2> mark st2
	C:\Program Files\Sublime Text 2> cd \
	C:\> jump st2
	C:\Program Files\Sublime Text 2> marks
	st2        -> C:\Program Files\Sublime Text 2
	C:\Program Files\Sublime Text 2> unmark st2
```
