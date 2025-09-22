# Veículo – Tracker (0..1) e LicensePlate (1:1)
## Cenário Escolhido
O cenário para esta atividade conta com a classe Vehicle (Veículo), que contém as entidades:
- LicensePlate (1:1 obrigatório).
- Tracker (0..1 opcional).

## Invariantes
LicensePlate (1:1)
- Todo veículo sempre tem uma placa.
- A placa não pode ser nula.
- A placa é imutável após a criação.

Tracker (0..1)
- Um veículo pode ter no máximo 1 rastreador.
- Não pode haver sobrescrita silenciosa (não troca se já existir).
- O rastreador pode ser removido, retornando a null.

## Navegabilidade
A relação foi modelada em apenas um sentido (Veículo → Placa/Rastreador).

Só seria bidirecional se houvesse necessidade explícita de navegar de Placa/Rastreador para o Veículo, o que não é o caso neste domínio.


## Decisões de Projeto
Encapsulamento: propriedades private set ou somente leitura.

Validação na fronteira: construtor e métodos não aceitam null ou valores inválidos.

Imutabilidade útil: a LicensePlate nunca pode ser alterada após a criação.

## Esse cenário demonstra como garantir as multiplicidades 0..1 e 1:1 por design, preservando os invariantes do domínio.
