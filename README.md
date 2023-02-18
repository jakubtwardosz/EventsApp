# EventApp to aplikacja WebAssembly platformy Blazor, hostowana przez aplikację ASP.NET Core.
## Opis funkcjonalności
### Dowolny użytkownik ma dostęp do:
  - Strony głównej z listą wydarzeń,
  - Strony logowania, 
  - Strony rejestracji.
### Zarejestrowany użytkownik może:
  - Dodać, edytować, usunąć kategorię,
  - Dodać, edytować, usunąć wydarzenie.
#### Wydarzenie powinno zawierać
  - Tytuł,
  - Opis,
  - Datę rozpoczęcia,
  - Kategorię,
  - Adres,
  - Koszt wstępu,
  - Zdjęcie



## Struktura projektu

### EventApp.Client – Aplikacja Blazor WebAssembly

#### Client\Properties\launchSetting.json - plik konfiguracyjny:
  - IDE wykrywa, że uruchamiamy aplikację WebAssembly,
  - Pozwala ustawić profile dla środowisk uruchomieniowych maszyn lokalnych,
  - Jest używany tylko na lokalnej maszynie programistycznej.

#### Client\wwwroot
 - Folder zawiera pliki statyczne aplikacji m.in. pliki HTML, CSS, grafiki i skrypty JavaScript.

#### Client\Program.cs 
  - Wskazywany jest element DOM „#app” w którym generowany jest główny komponent,
  - Deklarowane jest w jaki sposób ma być dodawana zawartość do znacznika head
  -	Rejestrowane instancji usług za pomocą AddScoped w ramach tego samego zapytania,
  -	Tworzony jest WebAssemblyHost, który obsługuje logowanie zdarzeń, zarządzanie konfiguracją i kieruje cyklem życia aplikacji.

#### Client\Pages
 - Folder z komponentami do których możemy bezpośrednio nawigować
 - Folder z komponentami do których możemy bezpośrednio nawigować, które wymagają uwierzytelnienia

#### Client\Services
  - Warstwa usług. Każda z nich posiada:
    - Interfejs, który określa jak dostęp do danych powinien wyglądać
    - Logikę, wraz z zapytaniami do API

#### Client\Shared
  - Komponenty wielokrotnego użytku, style CSS.

#### Client\ _Imports.razor
  - Lista przestrzeni nazw dodawanych do każdego komponentu.

#### Client\App.razor
  - Router odpowiedzialny za nawigację i wyświetlanie zawartości.

#### CustomAuthStateProvider.cs
  - Niestandardowa implementacja usługi AuthStateProvider odpowiedzialnej za komponent AuthorizeView.

Lista zależności do zewnętrznych pakietów:
  - `Blazored.LocalStorage` – biblioteka zapewniająca dostęp do interfejsu Storage przeglądarki,
  -	`Microsoft.AspNetCore.Components.Authorization` - udostępnia klasy do pobierania informacji o bieżącym stanie uwierzytelniania,
  -	`Microsoft.AspNetCore.Components.WebAssembly` – pozwala tworzyć aplikacje SPA uruchamiane po stronie klienta za pomocą Blazor działającego pod WebAssembly,
  - Odwołanie do projektu `EventApp.Shared` w którym znajdują się modele danych.

### EventApp.Server – WebAPI
#### Server\Controllers
 - Kod odpowiedzialny za obsługę żądań HTTP, który współdziała z warstwą usług (servcies)
#### Server\Data\DataContext.cs
  - Klasa kontekstowa dziedzicząca po `DbContext`, która
  - Definiuje właściwości bazy za pomocą `DbSet<TEntity>`,
  - Konfiguruje model bazy za pomocą metofy `OnModelCreating`,
  - Konfiguruje dostęp do bazy danych w metodzie `OnConfiguring`.
#### Server\Migrations
  - Synchronizacja schematu bazy danych z modelem EF Core,
#### Server\Pages
  - `Error.cshtml` - Domyślna strona błędu
#### Server\Services
  - `AuthService` - rozbudowana klasa obsługująca logowanie, rejestrację, weryfikację, tworzenie JSON Web Tokenu, tworzenie, przywracanie i weryfikację hasła,
  - `CategoryService` - usługa odpowiedzialna za wyświetlanie i modyfikowanie kategorii,
  - `CategoryService` - usługa odpowiedzialna za wyświetlanie i modyfikowanie wydarzeń.

`appsetting.json` - plik konfiguracyjny z ustawieniami hosta i tokenem autoryzującym.

`Program.cs` - plik konfiguracyjny do uruchomienia aplikacji w którym dodawane są usługi za pomocą `AddScoped`, dodawana jest obsługa kontekstu bazy danych.

### EventApp.Shared 
  - Klasy używane do przechowywania informacji o poszczególnych obiektach w aplikacji.
