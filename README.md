# ProjetWebService

**Groupe** :
- Quentin Dubois
- Ambre Correia

Étudiants de Polytech Nice Sophia dans la filière Sciences Informatiques

## Éléments réalisés dans le projet :
- Tous les requis minimums
- ProxyCache Générique
- Map java coté client

## Lancement du projet

Afin de faciliter l'exécution des éléments du projet, nous avons créé des scripts. Pour toutes les parties vous aurez la possibilité entre lancer un script ou de rentrer les commandes manuellement. Les scripts et les commandes sont à exécuté dans un terminal Windows.

### Serveur C#

Dans cette partie deux exécutables sont nécessaires. 

Script :
- `& '.\wt run serveurs.bat'`

Manuellement :
- `.\C#\ProxyCache\bin\Debug\ProxyCache.exe`
- `.\C#\ApplicationServer\bin\Debug\ApplicationServer.exe`

### Client lourd Java

Script : 
- `& '.\wt run java client.bat'`

Manuellement :
- `cd java\ClientBikeApplication\`
- `mvn compile exec:java`

## Fonctionnement du client Java

Le programme java demande de rentrer deux adresses physiques et affiche un trajet pour arriver du point A vers le point B. Ce trajet peut soit être un mix de vélo et à pied ou entièrement à pied en fonction de certaines conditions.
