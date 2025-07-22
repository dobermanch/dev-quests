# Hearthstone

## Rules

1. Mana System

- Each player begins the game with 1 mana crystal.
- After each round, players gain 1 additional crystal, up to a maximum of 10.
- All mana crystals fully regenerate at the start of a new turn.
- Example: Round 1 = 1 mana, Round 2 = 2 mana, and so on until capped at 10.

2. Player Deck Composition (30 Cards Total) Each deck contains:

- 10 cards: Deal 1 damage, cost 1 mana.
- 4 cards: Deal 2 damage, cost 2 mana.
- 2 cards: Deal 3 damage, cost 3 mana.
- 2 cards: Deal 4 damage, cost 4 mana.
- 2 cards: Deal 5 damage, cost 5 mana.
- 5 cards: Heal 1 hit point, cost 1 mana.
- 2 cards: Heal 2 hit points, cost 2 mana.
- 2 cards: Deal 1 damage, draw a card, cost 1 mana.
- 1 legendary card:
- Deals 4 damage.
- Grants 1 bonus mana crystal that turn.
- Costs 5 mana.
- Displays: "You will never defeat me!" in the UI.

3. Game Initialization

- Each player uses a unique deck.
- Players start with 4 randomly drawn cards and 30 hit points.

4. Gameplay Rules

- Cards are played based on available mana; no board presence is involved.
- Played cards are discarded immediately.
- Players may play multiple cards per turn, limited only by mana.
- Spending all available mana is optional.
- Damage cards affect the opponent only.
- Healing cards benefit only the player.

5. Turn Progression

- At the start of each turn, players draw one card.
- If all 30 cards have been drawn, the player loses 1 hit point per turn thereafter.

6. Victory Condition

- The game ends when a player's hit points reach 0 or below.

7. Turn Timing

- No time restrictions per turn.

8. End-of-Game Report

- Upon match completion, generate a summary report for both players:
- Deck composition
- Win/loss outcome
- Actions performed during each turn

## Build and Run

``` bash
dotnet run --project ./Hearthstone.csproj
```

``` bash
dotnet test ./Hearthstone.csproj
```
