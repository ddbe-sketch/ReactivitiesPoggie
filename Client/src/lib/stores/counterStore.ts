import { makeAutoObservable } from "mobx";
export default class CounterStore {
  title = "Counter store";
  count = 69;
  events: string[] = [`Intial count is ${this.count}`];

  constructor() {
    makeAutoObservable(this);
  }

  increment = (amount = 1) => {
    this.count += amount;
    this.events.push(`Incremended by ${amount} - count is now ${this.count}`);
  };

  decrement = (amount = 1) => {
    this.count -= amount;
    this.events.push(`Decremended by ${amount} - count is now ${this.count}`);
  };

  get eventCount() {
    return this.events.length;
  }
}
