# Sequence Diagrams — My Daniel Management System

**Phase:** Design
**Version:** 1.0 | **Date:** June 2026

> Sequence diagram images are the source of truth. Export each diagram from the modeling tool and save as `sequence-diagram-<uc-id>.png`.

![sequence diagram](sequence-diagram.png)

---

## TODO — Content to extract from sequence diagram source

No sequence diagram source was found in the project PDFs or VPP files at the time of document creation. Fill in the sections below once the diagrams are available. One section per UC.

---

## Sequence Diagram Template

> **TODO:** For each UC that has a sequence diagram, add a section below using this format:

---

### UC-XX — [UC Name]

**Diagram file:** `sequence-diagram-ucXX.png`

#### Participants (Lifelines)

> **TODO:** List all participants (actors and system components) that appear as lifelines in the diagram.

| Participant | Type |
| :--- | :--- |
| Actor / UI Panel / Controller / Database | Human / UI / Logic / Data |

#### Message Sequence

> **TODO:** List all messages in order, with parameters and return values.

| # | From | To | Message | Parameters | Returns |
| :--- | :--- | :--- | :--- | :--- | :--- |
| 1 | Actor | UIPanel | actionName() | param1, param2 | — |
| 2 | UIPanel | Controller | methodName(param) | param | result |

#### Fragments

> **TODO:** Document any `alt`, `opt`, `loop`, or `ref` combined fragments in the diagram:

```
alt [condition]
  ...messages...
else [alternative condition]
  ...messages...
end
```

---

## Notes

- One sequence diagram per use case is recommended.
- `.png` exports will be placed at `docs/design/sequence-diagram-<uc-id>.png` once exported from the modeling tool.
