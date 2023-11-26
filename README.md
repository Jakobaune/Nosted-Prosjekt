# Nosted Service Pro

Velkommen til Nosted Service Pro-prosjektet! Dette systemet er utviklet for å håndtere serviceordrer og relatert funksjonalitet.

## Dokumentasjon

For detaljert dokumentasjon om koden og prosjektet, vennligst sjekk vår [Wiki](https://github.com/Jakobaune/Nosted-Prosjekt/wiki).

## Funksjoner

- Administrasjon av serviceordrer med tilhørende sjekklister
- Bruker- og rollestyring
- Historikk og arkivering av serviceordrer

## Installasjon

1. Klon repoet: `git clone https://github.com/Jakobaune/Nosted-Prosjekt.git` til en egen mappe
2. Naviger til prosjektmappen: `cd dittmappenavn`
3. skriv følgende i terminal: `docker pull mariadb`.
4. Skriv følgende i terminal: `docker run --name nosted-mariadb -p 127.0.0.1:3306:3306/tcp -v /RUTETILDINRMAPPE:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=nosted123 -d mariadb:latest`.
8. Åpne løsningen i din foretrukne IDE
9. Åpne filen `Program.cs` endre linje 17 til følgende: ` "Server=127.0.0.1;Database=nosteddb;User=root;Password=nosted123;Port=3306;SslMode=none;";`
10. Navgiger til din repo mappe `cd Nosted-Prosjekt` deretter `cd NostedServicePro`
11. Skriv inn `dotnet ef database update` i din terminal
12. Endre deretter `Program.cs` linje 17 til følgende: `"Server=host.docker.internal;Database=nosteddb;User=root;Password=nosted123;Port=3306;SslMode=none;"; `

13. For å bygge applikasjonen skriv følgende i terminal: `dotnet build -t:nostedservicepro . `
14. Deretter legger du til docker support og kjørerprogrammet med docker i din IDE

#### Brukernavn og passord
- Brukernavn: Admin
- Passord: Admin123!


## Problemer og Feil

Hvis du oppdager noen problemer eller feil, vennligst rapporter dem i [Issue Tracker](https://github.com/Jakobaune/Nosted-Prosjekt/issues).
