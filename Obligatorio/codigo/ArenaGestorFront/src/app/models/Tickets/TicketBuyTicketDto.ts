import { SnackBuySnackDto } from "../Snacks/SnackBuySnackDto";

export class TicketBuyTicketDto {
  concertId: Number = 0;
  Amount: Number = 0;
  Snacks: Array<SnackBuySnackDto> = [];
}
