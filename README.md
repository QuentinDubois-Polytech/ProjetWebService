# ProjetWebService

**Groupe** :
- Quentin Dubois
- Ambre Correia

Étudiants de Polytech Nice Sophia dans la filière Sciences Informatiques

## Éléments réalisés dans le projet :
- Tous les requis minimums
- ProxyCache Générique
- Map coté client java

## Lancement du projet

### Prérequis
- Windows (pour lancer les serveurs)
- Java 17 (ou plus récent)
- Maven présent dans le PATH (pour la compilation du client java)

Afin de faciliter l'exécution des éléments du projet, nous avons créé des scripts. 
Pour toutes les parties, vous aurez la possibilité entre lancer un script ou rentrer 
les commandes manuellement. Les scripts et les commandes sont à exécuter dans un terminal Windows.

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

Le programme java demande de rentrer deux adresses physiques, l'adresse de départ et l'adresse d'arrivée.
Le client affichera le trajet le plus court entre ces deux adresses avec un mix de vélo et de marche à pied
ou totalement de marche à pied en fonction de certaines conditions.

### Remerciements

Nous tenions à remercier Florian Latapie qui nous a fourni les scripts bat et aidé pour la configuration du
pom.xml du projet java. Vous pouvez retrouver son [Github](https://github.com/FlorianLatapie) si cela vous 
intéresse.
