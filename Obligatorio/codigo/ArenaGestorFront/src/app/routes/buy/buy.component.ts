import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SnackBuySnackDto } from 'src/app/models/Snacks/SnackBuySnackDto';
import { SnackResultSnackDto } from 'src/app/models/Snacks/SnackResultSnackDto';
import { TicketBuyTicketDto } from 'src/app/models/Tickets/TicketBuyTicketDto';
import { ConcertService } from 'src/app/services/concert.service';
import { SnackService } from 'src/app/services/snack.service';
import { TicketsService } from 'src/app/services/tickets.service';

@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html'
})
export class BuyComponent implements OnInit {

  selectedTourName: String = "";
  selectedId: Number = 0;
  amount: Number = 0;
  snacksList: Array<SnackBuySnackDto> = new Array<SnackBuySnackDto>();
  snacksSubTotal: number = 0;

  constructor(private toastr: ToastrService, private ticketService: TicketsService, private concertService: ConcertService, private snackService: SnackService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.concertService.GetById(params["id"]).subscribe(concert => {
        this.selectedTourName = concert.tourName;
        this.selectedId = concert.concertId;
      });
    });
    this.GetSnacks();
    console.log('hiii')

  }
  GetSnacks() {
    this.snackService.Get({ name: '' }).subscribe(res => {
      this.snacksList = res.map((snack: SnackResultSnackDto) => {
        return {
          snackId: snack.snackId,
          name: snack.name,
          price: Number(snack.price),
          amount: 0
        }
      })
    })
  }

  Confirmar() {
    let dto = new TicketBuyTicketDto();
    dto.Amount = this.amount;
    dto.concertId = this.selectedId;
    dto.Snacks = this.snacksList
    this.ticketService.Shopping(dto).subscribe(res => {
      this.toastr.success("Ticket comprado con ID: " + res.ticketId);

    }, error => {
      this.toastr.error(error.error);
    });
  }
  RecalcularSubtotal() {
    this.snacksSubTotal = 0;
    this.snacksList.forEach((snack: SnackBuySnackDto) => {
      if (snack.amount < 0) {
        snack.amount = 0;
      } else {
        this.snacksSubTotal = this.snacksSubTotal + (snack.amount * snack.price);
      }
    });
  }
}
