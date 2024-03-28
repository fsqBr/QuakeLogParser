This project is built in .Net 8, you need to install the Runtime to run the project
https://dotnet.microsoft.com/pt-br/download/dotnet/8.0
<br/><br/>
The project **QuakeLogParser.Domain** contains all the services and entities who is necessary to make the project running
The project **QuakeLogParser.Infrastructure** contains the setup of the dependency injections
The project **QuakeLogParser.Domain.Test** contains a simple unit test from the domain
The project **QuakeLogParser.Application** contains a simple front with the responsability to get the log file and parsed

There is 3 possible results <br/><br/>
1 - **[Priview Log]** button  -> Parsed the quake log file with all the games<br/>
2 - **[Match Report]** button -> Parsed report with no Weapon stats **[With Weapon checkbox unchecked]**<br/>
3 - **[Match Report]** button -> Parsed report with Weapon stats **[With Weapon checkbox checked]**<br/>

All the results returns a Json file and its possible to save **[Save Report button]** in your computer
<br/><br/>

**[Priview Log] Example**
```
{
  "Game_1": {
    "id": "1d2e5933-81ae-47b6-aae8-1f26935a5914",
    "name": "Game_1"
  },
  "Game_2": {
    "id": "b74ab66a-7796-47d0-8685-2a055ccc5e72",
    "name": "Game_2",
    "game_matchs": [
      {
        "id": "69cfb424-72e6-4f06-89a3-b7600f095965",
        "player": "\u003Cworld\u003E",
        "action": 0,
        "weppon": "MOD_TRIGGER_HURT",
        "is_player": false
      },
      {
        "id": "69cfb424-72e6-4f06-89a3-b7600f095965",
        "player": "Isgalamido",
        "action": 1,
        "is_player": true
      },
```

**[Match Report - unchecked]**

```
{
  "game_1": {
    "total_kills": 11,
    "players": [
      "Isgalamido",
      "Mocinha"
    ],
    "kills": {
      "Isgalamido": -7,
      "Mocinha": -1
    }
  },
  "game_2": {
    "total_kills": 4,
    "players": [
      "Isgalamido",
      "Mocinha",
      "Zeh",
      "Dono da Bola"
    ],
    "kills": {
      "Isgalamido": 1,
      "Mocinha": -1,
      "Zeh": -2,
      "Dono da Bola": -1
    }
  },
}
```

**[Match Report - checked]**

```
{
  "game_1": {
    "total_kills": 11,
    "players": [
      "Isgalamido",
      "Mocinha"
    ],
    "kills": {
      "Isgalamido": -7,
      "Mocinha": -1
    },
    "kills_by_means": {
      "MOD_TRIGGER_HURT": 7,
      "MOD_ROCKET_SPLASH": 3,
      "MOD_FALLING": 1
    }
  },
  "game_2": {
    "total_kills": 4,
    "players": [
      "Isgalamido",
      "Mocinha",
      "Zeh",
      "Dono da Bola"
    ],
    "kills": {
      "Isgalamido": 1,
      "Mocinha": -1,
      "Zeh": -2,
      "Dono da Bola": -1
    },
    "kills_by_means": {
      "MOD_ROCKET": 1,
      "MOD_TRIGGER_HURT": 2,
      "MOD_FALLING": 1
    }
  },
}
```

**This approach was made to be as simple and direct as possible and easy to maintain.**
