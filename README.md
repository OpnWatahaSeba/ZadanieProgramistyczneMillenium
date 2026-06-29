# Zadanie Programistyczne - Weryfikacja Akcji Karty

Aplikacja API POC - zbudowana w oparciu o **.NET 8** służąca do automatycznej weryfikacji dozwolonych akcji dla kart płatniczych na podstawie dostarczonej matrycy kryteriów.

## 🛠️ Jak uruchomić projekt lokalnie

1.  Upewnij się, że masz zainstalowane **.NET 8.0 SDK** lub nowsze oraz Visual Studio 2022.
2.  Sklonuj repozytorium:
    ```bash
    git clone [https://github.com/OpnWatahaSeba/ZadanieProgramistyczneMillenium.git](https://github.com/OpnWatahaSeba/ZadanieProgramistyczneMillenium.git)
    ```
3.  Otwórz plik rozwiązania `ZadanieProgramistyczneMillenium.sln` w Visual Studio.
4.  Uruchom projekt za pomocą profilu `IIS Express` lub profilu aplikacji (zielona strzałka).
5.  Aplikacja automatycznie otworzy przeglądarkę na stronie **Swagger UI** under adresem `http://localhost:[port]/swagger`.

---

## 🏗️ Architektura i Funkcjonalności

Projekt został zaprojektowany z myślą o czytelności, wydajności oraz łatwości rozbudowy:
* **Zoptymalizowany Silnik Reguł:** Reguły biznesowe dla matrycy akcji zostały zaimplementowane w oparciu o słownik delegatów `Dictionary<string, Func<CardDetails, bool>>`. Pozwala to na sprawdzanie złożonych warunków w czasie $O(1)$ i eliminuje potrzebę pisania kilkunastu zagnieżdżonych instrukcji `if-else`.
* **Globalna Obsługa Błędów:** Wdrożono `IExceptionHandler` wprowadzony w .NET 8, który przechwytuje nieobsługiwane wyjątki w aplikacji i mapuje je na standaryzowany format zgłaszania błędów **Problem Details** (RFC 7807).

### 📝 Logowanie Ruchu (HTTP Logging)
W aplikacji skonfigurowano wbudowany middleware `HttpLogging`, który automatycznie rejestruje metodę żądania, ścieżkę oraz kod statusu odpowiedzi (StatusCode). 

Aby logi były czytelne i nie zajmowały wielu linii w środowisku deweloperskim, w pliku `appsettings.Development.json` skonfigurowano formatowanie typu **Simple Console**.
> 💡 **Wskazówka:** Aby zobaczyć sformatowane, jednolinijkowe logi w Visual Studio, zmień strumień wyjściowy w oknie *Output* ("Show output from") na profil aplikacji zamiast ogólnego profilu *Debug*.

---

## 🧪 Przykładowe Zapytanie (API Endpoint)

**Endpoint:** `POST /api/Cards/allowed-actions`

**Request Body (JSON):**
json
{
  "userId": "User1",
  "cardNumber": "Card11"
}

**Response Body (JSON):**
json
{
  "userId": "User1",
  "cardNumber": "Card11",
  "allowedActions": [
    "Action1",
    "Action2"
  ]
}