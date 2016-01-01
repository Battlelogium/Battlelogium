import site
import os
import subprocess

#checks for a the pyinstaller file in the sites packages folder and returns it if it exists, or empty if not existing
def getPyinstaller(fileToCheck):
    pyinstaller = os.path.join(site.getsitepackages()[0], "Scripts", fileToCheck)

    if os.path.exists(pyinstaller):
        return pyinstaller
    return False

def build():

    buildArguments = ['steam_shortcut_manager_cli.py', '-y', '--console', '--onefile', '--clean', '--noupx']

    #checking for the pip release version
    pyinstaller = getPyinstaller("pyinstaller.exe")
    if pyinstaller:
        buildargs=[pyinstaller] + buildArguments
    #checking for the developer non-compiled version
    else:
        pyinstaller = getPyinstaller("pyinstaller-script.py")
        if pyinstaller:
            buildargs=['python', pyinstaller] + buildArguments
        else:
            raise IOError("PyInstaller is required to build for windows")
    
    subprocess.call(' '.join(buildargs))
    
if __name__ == "__main__":
    build()
