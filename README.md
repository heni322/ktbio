# KT Bio - Gestion d'Inventaire

Ce projet est une application de gestion d'inventaire connectée à une base de données Sage 100 SQL.

## 🚀 Comment lancer le projet

Pour faire fonctionner l'application, vous devez lancer le **Backend** et le **Frontend** dans deux terminaux séparés.

### 1. Démarrer le Backend (.NET API)
Sert les données depuis SQL Server.
- **Dossier** : `backend\KTBioAPI`
- **Commande** :
  ```powershell
  dotnet run
  ```
- **Note** : Si le serveur est déjà utilisé ou bloqué, utilisez cette commande pour forcer le redémarrage :
  ```powershell
  taskkill /F /IM KTBioAPI.exe /T ; dotnet run
  ```

### 2. Démarrer le Frontend (React App)
L'interface utilisateur.
- **Dossier** : `app`
- **Installation** (seulement la première fois) :
  ```powershell
  npm install
  ```
- **Commande** :
  ```powershell
  npm run dev
  ```

---

## 🔑 Accès
Une fois les deux serveurs lancés :
- Ouvrez votre navigateur sur : **http://localhost:5173**
- Connectez-vous avec vos identifiants utilisateur.

## 🛠 Technologies
- **Backend** : .NET Core 8, EF Core, SQL Server (Sage 100)
- **Frontend** : React, TypeScript, Tailwind CSS, Shadcn UI
