# PowerJump
-----

Quick commandline navigation by bookmarks (jumps). Supercedes my old [shelljump](https://github.com/kjerk/shelljump) project, as a binary powershell module.

Add to your PS profile with

```Import-Module .\Path\To\Module\PowerJump.psd1```

Inspired by "Quickly navigate your filesystem from the command-line"
http://tinyurl.com/nx6wzvq

Allows for bookmarking of folders under aliases and the capability to jump to them, 
persisting between shell sessions in an (editable) json file.

### Command aliases:
    jumps           | List all existing bookmarks.
    j (alias)       | Jump to a bookmarked folder.
    jump (alias)    | Jump to a bookmarked folder.
    mark (alias)    | Bookmarks current directory with a given alias.
    unmark [alias]  | Removes alias.
    loadjumps       | Reloads .json file into shell (if edited or out of date)
    savejumps       | Overwrite .json file with current jumps
    editjumps       | Open .json file in default editor, await exit, and reload.
	
### Underlying functions -> related alias:
    Add-Jump     -> mark
    Edit-Jumps   -> editjumps
    Find-Jump    -> jump, j
    Import-Jumps -> loadjumps
    Get-Jumps    -> jumps
    Remove-Jump  -> unmark
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
    C:\Program Files\Sublime Text 2> jumps
    st2        -> C:\Program Files\Sublime Text 2
    C:\Program Files\Sublime Text 2> unmark st2
```
