# dotnet-pokeapi
A .NET Core Web API that consumes the PokeAPI

## GET    /api/pokemon/
          Retrieves a list of pokémon. Accepts parameters [page] and [items] number for pagination.

## GET    /api/pokemon/{id or name}
          Retrieves the date of a single pokémon.

## GET    /api/favorite
          Retrieves a list of favorited pokémon.

## GET    /api/favorite/{id}
          Retrieves a single favorited pokémon.

## POST   /api/favorite
          Adds a new pokémon to favorites.

## DELETE /api/favorite/{id}
          Delete a pokémon from favorites.
