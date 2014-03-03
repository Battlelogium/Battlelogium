import sys
import os
import steam_shortcut_manager
import steam_location_manager

def insert_shortcut(manager, name, exe, icon=""):
    manager.add_shortcut(name, "\""+exe+"\"", "\""+os.path.dirname(exe)+"\"", icon=icon)
    manager.save()

def run():

    if sys.argv.__len__() < 4:
        print "Invalid args - steam_shortcut_manager_cli userid gamename gameexe. userid = all will loop all userids"
        return

    userid = sys.argv[1]
    gamename = sys.argv[2]
    gameexe = sys.argv[3]

    if userid == "all":
        for uid in steam_location_manager.user_ids_on_this_machine():
            try:
                vdf = steam_location_manager.shortcuts_file_for_user_id(
                    steam_location_manager.userdata_directory_for_user_id(uid)
                )
                manager = steam_shortcut_manager.SteamShortcutManager(vdf)
                insert_shortcut(manager, gamename, gameexe)
                print "Inserted Shortcut {0}:{1} to id {2}".format(gamename, gameexe, uid)
            except:
                continue
    else:
        vdf = steam_location_manager.userdata_directory_for_user_id(userid)
        manager = steam_shortcut_manager.SteamShortcutManager(vdf)
        insert_shortcut(manager, gamename, gameexe)
        print "Inserted Shortcut {0}:{1} to id {2}".format(gamename, gameexe, userid)
    return

if __name__ == "__main__":
    run()