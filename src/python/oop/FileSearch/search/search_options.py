from dataclasses import dataclass

@dataclass
class SearchOptions:
    is_recursive: bool
    is_caseSensitive: bool