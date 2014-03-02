import os

def windows_steam_location():
    import _winreg as registry
    key = registry.CreateKey(registry.HKEY_CURRENT_USER,"Software\Valve\Steam")
    return registry.QueryValueEx(key,"SteamPath")[0]

def windows_userdata_location():
    # On Windows, the userdata directory is the steamshortcut installation directory
    # with 'userdata' appeneded
    return os.path.join(windows_steam_location(),"userdata")

def user_ids_on_this_machine():
    """
    Reads the userdata folder to find a list of IDs of Users on this machine.
    This function returns the user_ids in the communityid32 format, so use
    those related methods to convert to other formats

    The userdata folder contains a bunch of directories that are all 32 bit
    community ids, so to find a list of ids on the machine we simply find a
    list of subfolders inside the userdata folder
    """
    ids = []
    userdata_dir = windows_userdata_location()
    for entry in os.listdir(userdata_dir):
        if os.path.isdir(os.path.join(userdata_dir,entry)):
            ids.append(int(entry))
    return ids

def userdata_directory_for_user_id(user_id):
    """
    Returns the path to the userdata directory for a specific user

    The userdata directory is where Steam keeps information specific to certain
    users.
    """
    return os.path.join(windows_userdata_location(), str(user_id))

def shortcuts_file_for_user_id(user_id):
    """
    Returns the path to the shortcuts.vdf file for a specific user

    This is really just a convenience method, as it just calls
    userdata_directory_for_user_id, and then adds the path element
    /config/shortcuts.vdf to the result
    """
    return os.path.join(os.path.join(userdata_directory_for_user_id(user_id),"config"),"shortcuts.vdf")