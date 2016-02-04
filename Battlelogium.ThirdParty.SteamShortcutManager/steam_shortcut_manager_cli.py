import sys
import os

#Thanks https://github.com/scottrice/pysteam/tree/868d08c9045fda9ce98bd21b7e87876e3652adf2
import steam
import shortcuts
import model

def insert_shortcut(userContext, name, exe, icon="", tags=[]):

    shortcutList = shortcuts.get_shortcuts(userContext)

    shortcutList.append(model.Shortcut(name, "\""+exe+"\"", "\""+os.path.dirname(exe)+"\"", icon=icon, tags=[]))

    shortcuts.set_shortcuts(userContext, shortcutList)

    print "Inserted Shortcut {0}:{1} to id {2}".format(name, exe, userContext["user_id"])

def run():

    if sys.argv.__len__() < 4:
        print "Invalid args - steam_shortcut_manager_cli userid gamename gameexe. userid = all will loop all userids"
        return

    userid = sys.argv[1]
    gamename = sys.argv[2]
    gameexe = sys.argv[3]

    steamObj = steam.get_steam()

    if userid == "all":
        for userContext in steam.local_user_contexts(steamObj):
            try:

                insert_shortcut(userContext, gamename, gameexe)

            except:
                continue
    else:

        for userContext in steam.local_user_contexts(steamObj):

            if userContext["user_id"] == userid:
                try:

                    insert_shortcut(userContext, gamename, gameexe)

                finally:
                    break
    return

if __name__ == "__main__":
    run()