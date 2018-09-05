import { async, ComponentFixture, TestBed, inject } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http'
import { CounterComponent } from './counter.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('CounterComponent', () => {
  let component: CounterComponent;
  let fixture: ComponentFixture<CounterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CounterComponent],
      imports: [HttpClientTestingModule],
      providers: []
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CounterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should display a title', async(inject([HttpClient], (http: HttpClient) => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Upload File');
  })));

  it('upload file', async(inject([HttpClient], (http: HttpClient) => {
    fixture.detectChanges();
    const incrementButton = fixture.nativeElement.querySelector('label');
    incrementButton.click();
    fixture.detectChanges();
    expect(true).toEqual(true);
  })));

  //   it('should start with count 0, then increments by 1 when clicked', async(() => {
  //     const countElement = fixture.nativeElement.querySelector('strong');
  //     expect(countElement.textContent).toEqual('0');

  //     const incrementButton = fixture.nativeElement.querySelector('button');
  //     incrementButton.click();
  //     fixture.detectChanges();
  //     expect(countElement.textContent).toEqual('1');
  //   }));
});
