<p align="center">
  <img alt="pazword logo" src="./Assets/Icon.png" width="100px" />
  <h1 align="center">PaZword</h1>
</p>

[![Downloads](https://img.shields.io/github/downloads/veler/PaZword/total.svg?label=Downloads)](https://github.com/veler/PaZword/releases/)
[![Release](https://img.shields.io/github/release/veler/PaZword.svg?label=Release)](https://github.com/veler/PaZword/releases)
[![Contributors](https://img.shields.io/github/contributors/veler/PaZword?label=Contributors)](https://github.com/veler/PaZword/graphs/contributors)

A password manager made in UWP.

<a href='//www.microsoft.com/store/apps/9p47mfg7rxhd?cid=storebadge&ocid=badge'><img src='https://developer.microsoft.com/en-us/store/badges/images/English_get-it-from-MS.png' alt='Get PaZword on the Microsoft Store' width="284px" height="104px"/></a>

## Features

- Encryption of the vault.
- Notifies when a credential has leak on the dark web.
- Attach and encrypt up to 4 MB files.
- Password generator and strength evaluator.
- Synchronization with a personal cloud storage account, such like Microsoft OneDrive or DropBox.
- Authentication using Windows Hello (facial recognition, fingerprint, pin...).
- Authentication using two-factor authentication.
- Automatic detection of the best icon to associate with an account.
- Search function.

## Screenshots

![PaZword](https://medias.velersoftware.com/images/pazword/1.png)
![PaZword](https://medias.velersoftware.com/images/pazword/4.png)

## Languages

- English
- French
- Russian

See below to help with existing translations or add a new language.

## Would you like to help the project?

 * [Paypal donation](https://www.paypal.com/donate?hosted_button_id=T4NTSX8BYEAVL)
 * [Steam wishlist](https://store.steampowered.com/wishlist/id/velersoftware)
 * [Amazon wishlist](https://www.amazon.ca/hz/wishlist/ls/UCJ65HR9ZJSD?ref_=wl_share)
 * [Feedback (reporting bugs, ideas, etc)](https://github.com/veler/PaZword/issues/new/choose)
 * Create a review. :)

## Please, avoid selling this app as yours

I don't care if you copy the source code to use in your project, but please avoid simply changing the name and selling as your work. 
That's not why I'm sharing the source code, at all.

## How to install (as an end-user)

### Prerequisite
- You need Windows 10 build 1809 or later.

### Microsoft Store
- Search for PaZword in the Microsoft Store App or click [here](https://www.microsoft.com/en-us/p/pazword/9p47mfg7rxhd)

### Manual

- Download and extract the latest [release](https://github.com/veler/PaZword/releases).
- Double click the *.msixbundle file.

## How to set up a development environment

### Explore the repository online

Use Rich Code Navigation to explore the repository in the web browser with the support of Find All References, Go To Definition and other navigation features:

[https://online.visualstudio.com/github/veler/PaZword](https://online.visualstudio.com/github/veler/PaZword)

### On a local machine

1. Clone the repository.
2. Install Visual Studio 2019 by importing the following [configuration](https://github.com/veler/PaZword/blob/master/Windows/.vsconfig).
3. Rename `ServicesKeys-sample.txt` to `ServicesKeys.txt`.
4. (optional, but recommended) Complete `ServicesKeys.txt` if you need to debug OneDrive, DropBox, RiteKit, Two factor authentication and more.
5. Open the solution `Windows/PaZword.sln`
6. Generate a certificate. To do so, right click the project under the Solution Explorer -> Properties -> Package Manifest. Go to the "Packaging" tab -> Choose Certificate -> Create. You will be prompted to choose a password and then click OK.
7. Rebuild the solution.

### Edit the localizable strings

Any localizable string should be placed in `PaZword.Localization` project.
A [LanguageManager](https://github.com/veler/PaZword/blob/master/Windows/Impl/PaZword.Localization/LanguageManager.cs) service allows to bind any localizable string in XAML and update the UI by implementing [INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged).
This service is generated automatically. When editing a `.resw` file, be sure to regenerate the service by opening [LanguageManager.tt](https://github.com/veler/PaZword/blob/master/Windows/Impl/PaZword.Localization/LanguageManager.tt) and save (Ctrl+S).

### Versioning

The application version use the following pattern :

```
year.month.day.buildCountInTheDay
```

Each time that the solution is built in `Release` mode, version number are updated.

# Contribute

Feel free to contribute to this project in any way : adding feature, opening issues, translating.

# Third-Party Softwares

See [ThirdPartyNotices](https://github.com/veler/PaZword/blob/master/ThirdPartyNotices.md)

# License

See [LICENSE](https://github.com/veler/PaZword/blob/master/LICENSE.md)
