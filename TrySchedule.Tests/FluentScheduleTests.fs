module TrySchedule.Tests

open FluentScheduler
open System
open System.Diagnostics
open NUnit.Framework

module Job3 = 
    let start() = 
        let task() = Debug.WriteLine("Hello, world")
        let schedule (s : Schedule) = s.ToRunEvery(1).Seconds() |> ignore
        JobManager.AddJob(task, schedule)
        JobManager.AddJob(task, schedule)

module Job2 = 
    let start() = 
        let schedule = Schedule(fun () -> Debug.WriteLine("Hello, world!"))
        schedule.ToRunEvery(1).Seconds() |> ignore
        schedule.Execute()

module Job1 = 
    type Job() = 
        interface IJob with
            member this.Execute() = Debug.WriteLine("Hello, world!")
    
    type Reg() = 
        inherit Registry()
    
    let start() = 
        JobManager.Initialize(Reg())
        JobManager.AddJob<Job>(fun x -> x.ToRunNow().AndEvery(1).Seconds() |> ignore)

[<Test>]
let job3() =
    Job3.start()
    while Console.ReadLine() <> "q" do
        ()

[<Test>]
let job2() = 
    Job2.start()
    while Console.ReadLine() <> "q" do
        ()

[<Test>]
let job1() = 
    Job1.start()
    while Console.ReadLine() <> "q" do
        ()
