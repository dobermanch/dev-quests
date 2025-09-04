import os

class FileInfo:
    def __init__(self, file: os.DirEntry):
        self.__file = file

    @property
    def name(self) -> str:
        if self.__file.name.startswith('.'):
            return self.__file.name

        return os.path.basename(self.__file.name).split('.')[0]

    @property
    def extension(self) -> str:
        return os.path.basename(self.__file.name).split('.')[-1]

    @property
    def size(self) -> int:
        return os.stat(self.__file.path).st_size

    @property
    def path(self) -> str:
        return self.__file.path