import site
import os
import subprocess

def build():
    pyinstaller = os.path.join(site.getsitepackages()[0], "Scripts", "pyinstaller-script.py")
    if not os.path.exists(pyinstaller):
        raise IOError("PyInstaller is required to build for windows")
    print "PyInstaller check passed"
    buildargs=['python', pyinstaller, 'steam_shortcut_manager_cli.py', '-y', '--console', '--onefile', '--clean', '--noupx']
    subprocess.call(' '.join(buildargs))
if __name__ == "__main__":
    build()