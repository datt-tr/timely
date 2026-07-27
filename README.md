# Timely
**Timely - Arbeitszeiterfassungssystem**. Aktuell Phase 1

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
- sln Einrichtung
	- `dotnet new gitignore`
	- `dotnet new sln -n Timely`
	- `dotnet new webapi --use-controllers -o Timely.Api`
	- `dotnet new classlib -o Timely.Domain`
	- `dotnet sln add src\Timely.Api`
	- `dotnet add Timely.Api reference Timely.Application`
- Docker
	- `docker compose up --build`
	- `docker compose down`
	- ctrl + c - stoppt die Container

## Datenmodell
- TimeEvent
	- Id
	- TimeEventType
		- WorkStarted
		- WorkEnded 
		- PauseStart
		- PauseEnd
	- UserId
	- Timestamp
	- LocationType
		- Office
		- HomeOffice
- User
	- Id
	- Name
	- Surname
	- Email
	- Role
		- Employee
		- Admin
		- TeamLeader
	- ContractId
- EmploymentContract
	- Id
	- UserId
	- WeeklyTargetHours
	- ValidFrom
	- ValidUntil
- enum WorkStatus
	- Working
	- OnBreak
	- NotWorking
- Role
	- Employee
	- Admin
	- TeamLeader

## Funktionalität
- Phase 1
	- Office starten / enden
	- Pause starten / enden
	- HomeOffice starten / enden
	- Anmeldung / Registrierung
	- Aktuellen Status anzeigen
	- Monatsansicht (Journal)
		- Day, Type, Times Recorded, Quota Coverage, Quota, Balance, Total Balance
	- Rolle: Mitarbeiter
- Phase 2
	- Kalenderansicht
	- Andere TimeEvents
		- Urlaub / Krankheit / Ferien
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
- Extra
	- Zeitzonen

## Frontend
- WebTerminal
	- Vollname
	- Steuerung
		- Office Work Start
		- Home Office Work Start
		- Break Start
		- Break End
		- Work End
		- Status
			- HomeOffice Work / Office Work / Break / Absent
			- Work Hours: X
			- Break: X
- Kalender
	- Kalenderansicht
		- U - Urlaub (Grün)
		- KR - Krank (Rot)
		- F - Ferien (Blau)
		- Häkchen - Work
	- Zähler für U KR Work
	- Urlaubssaldo
		- Gesamturlaubstage
		- Genommene Urlaubstage
		- Geplante Urlaubstage
		- Verbleibende Urlaubstage


## API
nicht Restful aber angenehmer für Frontend Entwickler

| Funktion | Method | Endpunkt | Notizen
| - | - | - | - |
| Login | POST | `/api/v1/auth/login` |
| Logout | POST | `/api/v1/auth/logout` |
| Register | POST | `/api/v1/auth/register` |
| Me | GET | `/api/v1/auth/me` |
| |
| Start Work | POST | `/api/v1/time/work/start` | benötigt Location
| End Work | POST | `/api/v1/time/work/end` |
| Start Break | POST | `/api/v1/time/break/start` |
| End Break | POST | `/api/v1/time/break/end` |
| |
| Status | GET | `/api/v1/time/status` |
| |

## Docker
Für die Bereitstellung auf einem VPS wird Docker verwendet. Auch für die lokale Entwicklung wird Docker verwendet, um eine konsistente Umgebung zu gewährleisten.

Dockerfile, docker-compose.yaml und .env Datei für lokale Entwicklung und Bereitstellung

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

**Wichtig**:
- Optimistic Concurrency
- Race Conditions
- Idempotency Key


### Datenmodell
- Verschiedene Entries, falls jede eigene Regeln hat

### Geschäftsregeln
- Session
	- nur eine Session pro User
- Transaktion
	- Lesen und Speichern gehören in dieselbe Transaktion
- TimeEvent
	- TimeEvents können nur von Admin geändert werden.
	- Doppelte Anfragen dürfen keine doppelten Einträge erzeugen.
	- Zwei TimeEvent in derselben Minute müssen möglich sein.
	- Maximale Dauer: 24 Std.
	- Für Tagesberichte muss die Sitzung an der lokalen Tagesgrenze aufgeteilt werden.
- Location
	- Location kann nicht zwischen Start und Ende wechseln.
	- Location wird bei Break Start, Break End und Work End automatisch gesetzt.
- Status
	- Working / On Break / Absent.
	- Status wird aus den Events abgeleitet.
- Timestamp
	- Timestamp werden in UTC gespeichert und lokal angezeigt.
	- DateTimeOffset.
	- TimeProvider.Testing
- Arbeit
	- Arbeit kann nicht zweimal gestartet werden.
	- Arbeit kann nur beendet werden, wenn sie läuft.
	- Arbeit kann nicht während einer laufenden Pause beendet werden.
	- Arbeit über Mitternacht ist erlaubt.
- Pause
	- Pause kann nur während der Arbeit beginnen.
	- Pause kann nicht zweimal gestartet werden.

## ADRs (nocht nicht sicher)
- UTC
- einen Service für alle Funktionen statt Command, Handler, Validator, Request, Response, etc. pro Funktion zu haben <- Premature Optimization
- EmploymentContract ValidFrom und ValidUntil <- Wenn der Vertrag später von 40 auf 30 Stunden geändert wird, können sich historische Berechnungen rückwirkend verändern