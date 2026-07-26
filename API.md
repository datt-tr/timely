# API Dokumentation

## POST /time/break/start

``` json
{
  "status": "onBreak",
  "location": "homeOffice"
}
```

## GET /time/status

``` json
{
  "status": "working",
  "location": "homeOffice",
  "workedMinutesToday": 275,
  "breakMinutesToday": 30
}
```

## GET /auth/me

``` json
{
  "id": "73ff82c8-83a4-4a28-84c7-1b410f798a72",
  "firstName": "Max",
  "lastName": "Mustermann",
  "email": "max.mustermann@example.de",
  "role": "employee",
}
```

## GET /time/journal?year=2026&month=7

``` json
{
  "year": 2026,
  "month": 7,
  "timeZone": "Europe/Berlin",
  "calculatedAt": "2026-07-25T14:30:00Z",
  "openingBalanceMinutes": 120,
  "closingBalanceMinutes": 155,
  "days": [
    {
      "date": "2026-07-01",
      "dayOfWeek": "wednesday",
      "dayType": "workday",
      "recordedTimes": [
        {
          "type": "workStarted",
          "occurredAt": "2026-07-01T06:00:00Z",
          "location": "office"
        },
        {
          "type": "breakStarted",
          "occurredAt": "2026-07-01T10:00:00Z",
          "location": "office"
        },
        {
          "type": "breakEnded",
          "occurredAt": "2026-07-01T10:30:00Z",
          "location": "office"
        },
        {
          "type": "workEnded",
          "occurredAt": "2026-07-01T14:30:00Z",
          "location": "office"
        }
      ],
      "workedMinutes": 480,
      "breakMinutes": 30,
      "quotaMinutes": 480,
      "balanceMinutes": 0,
      "runningBalanceMinutes": 120,
    },
    {
      "date": "2026-07-02",
      "dayOfWeek": "thursday",
      "dayType": "workday",
      "recordedTimes": [],
      "workedMinutes": 0,
      "breakMinutes": 0,
      "quotaMinutes": 480,
      "balanceMinutes": -480,
      "runningBalanceMinutes": -360,
    }
  ]
}
```