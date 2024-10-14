# API de Gestion des Joueurs de Tennis

## Description

Cette API permet de g�rer des donn�es sur les joueurs de tennis, en fournissant des fonctionnalit�s pour r�cup�rer des informations sur les joueurs, trier les joueurs par rang et obtenir des statistiques.
Ce projet est une API Web Tennis construite en utilisant les principes de l'architecture Clean Arch et le Domain-Driven Design (DDD).
Il exploite MediatR pour g�rer les requ�tes et commandes, 
AutoMapper pour les mappages entre les entit�s et les DTOs 

## Fonctionnalit�s

- R�cup�rer tous les joueurs tri�s par rang.
- R�cup�rer les informations d'un joueur par son identifiant.
- Obtenir des statistiques sur les joueurs, y compris :
  - Le pays avec le plus grand ratio de parties gagn�es.
  - L'IMC moyen de tous les joueurs.
  - La m�diane de la taille des joueurs.

## Technologies Utilis�es

- **.NET 8** : Framework pour construire l'API.
- **MediatR** : Pour la gestion des requ�tes.
- **AutoMapper** : Pour le mapping des objets.
- **XUnit** : Pour les tests unitaires.

 