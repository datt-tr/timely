# Timely
**Timely - Arbeitszeiterfassungssystem**

## Notizen


## Verlauf
- Claude
	- [Claude Code Tutorial - Build Apps 10x Faster with AI](https://www.youtube.com/watch?v=IuyVVtr1uhY&t=1231s)
	- shift tab - verschiedene Modes
	- `/compact` - context leichter machen
	- `/clear` - context löschen
	- `/usage`
	- `/model`
	- `/rewind`
	- `/statusline`
	- vllt 
	- `/insights`
	- github mcp
	- context7
- cmd Befehle
	- `dotnet new gitignore`
	- `dotnet new sln -n Timely`
	- `dotnet new webapi --use-controllers -o Timely.Api`
	- `dotnet new classlib -o Timely.Domain`
	- `dotnet sln add src\Timely.Api`
	- `dotnet add Timely.Api reference Timely.Application`

## Datenmodell
- TimeEvent
	- Id
	- Type
		- OfficeStart
		- OfficeEnd
		- PauseStart
		- PauseEnd
		- HomeofficeStart
		- HomeofficeEnd
	- UserId
	- Timestamp
	- Location
- Vertrag
	- 40 Std / Woche
	- 8 Std / Tag

## Edge Cases
- office enden nach home office start
- Office Start nach OfficeStart
- zwei Entries in derselben Minute

## Extra
- Feiertage

- Zeitzonen

## Funktionalität
- Phase 1
	- Office starten / enden
	- Pause starten / enden
	- HomeOffice starten / enden
	- Anmeldung / Registrierung
	- Aktuellen Status anzeigen
	- Monatstabelle anzeigen
		- Day, Type, Times Recorded, Quota Coverage, Quota, Balance, Total Balance
	- Rolle: Mitarbeiter
- Phase 2
	- Mitarbeiter verwalten
	- Zeiterfassung korrigieren
	- Profil bearbeiten
	- Passwort ändern
	- Status von allen Mitarbeitern anzeigen
	- Rolle: Admin
- Phase 3
	- Vielleicht:
		- Urlaubsanfrage genehmigen
	- Rolle: Teamleiter

## API
nicht Restful aber angenehmer für Frontend Entwickler

| Funktion | Method | Endpunkt | Notizen
| - | - | - | - |
| Login | POST | `/api/v1/auth/login` |
| Register | POST | `/api/v1/auth/register` |
|
| Start Work | POST | `/api/v1/time/work/start` | benötigt Location
| End Work | POST | `/api/v1/time/work/end` |
| Start Break | POST | `/api/v1/time/break/start` |
| End Break | POST | `/api/v1/time/break/end` |
|
| Status | GET | `/api/v1/time/status` |
| Working hours | GET | `/api/v1/time/working-hours` |


## Git
- main (release branch)
- develop

## Monorepo
- Timely/
	- backend/
		- src/
			- Timely.Api/
			- Timely.Application/
			- Timely.Infrastructure/
			- Timely.Domain/
		- tests/
	- frontend/

## Technologie Stack
- C#
- Dokumentation
	- README.md
	- ARD (vllt)
- Bereitstellung
	- VPS
- Versionsverwaltung
	- Git
- Docker
- CI / CD
	- GitHub Actions
	- Automatische Tests und Bereitstellung
- Design
	- Architektur w/ Clean Architecture + Vertical Slices
	- DDD
	- SOLID Prinzipien
	- Result Pattern
	- Dependency Injection
- Monitoring
	- Logs, Metrics and Traces w/ OpenTelemetry 
	- Monitoring w/ Grafana
- Tests
	- TDD
	- Unit Tests w/ XUnit
	- Integration Tests w/ WebApplicationFactory
	- Mocking w/ NSubstitute
	- DB Tests w/ Testcontainers
- API
	- REST
	- Versionierung
- Api Testing
	- Swagger
	- Postman / Http Files
	- Debugger
- Styling / Analyzers
	- .editorconfig
	- Roslynator.Analyzers + SonarAnalyzer.CSharp
- Authentifizierung / Autorisierung 
	- JWT
	- Verschlüsselung
- DB
	- Postgres
	- Migrationen
	- EF Core
- Http Antworten
- Problem Details (RFC 9457)
- GlobalExceptionHandler
- Frontend
	- Angular 

## Doku
### Datenmodell
- Verschiedene Entries, falls jede eigene Regeln hat
