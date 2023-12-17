# To run this application:

$ __cd Sneaker__

$ __docker-compose -f docker-compose.yml -f docker-compose.debug.yml up__

### Migrate database (only run when using for the first time!):

$ __docker exec -w /app/aspnet -it sneaker-migration /root/.dotnet/tools/dotnet-ef database update__

 Run the maui app!

(__dotnet build -t:Run -f net7.0-android__) 






[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/C_wGfqQt)
