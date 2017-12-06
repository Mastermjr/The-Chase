# The-Chase
Game to allow multiple players to race to the end of  a course. Times are saved and recorded.

# Access from here:
https://mastermjr.github.io/The-Chase/

NOTES
index.html
    Leaderboards
        List Maps
            Fastest Run time
    HOW TO PLAY? (Look nice)
        Buttons and such
    WEBGL GAME
        Login
            Campaign: 10 maps

Database: (login handled)
    Users
        UserId: string
            UserName: string
            Maps: [ID0,...,IDn] //Highscores attained
Storage:
    Maps
        Id
        BestRun
        preview-image

EVERY TIME YOU CHANGE DIRECTIONS, you get faster!!!
Sometimes you even hop!!

TODO:
Mikey:
    implement Auth
    implement database calls in C# (returns in json)
    implement map object (wrapper for data from DB)
    implement database calls for front end
    help front end!


Kumar:
    make front end nice and modern!
    make the maps
    implement index, leaderboareds, how-to-play
    help dilon!

Dillon Davis:
    - tidy up the code
    - add sprite animations
    - integrate with mikey's functions


Future Features:
***Community Maps*** //future feature
