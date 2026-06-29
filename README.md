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