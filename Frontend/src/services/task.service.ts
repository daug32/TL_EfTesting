import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskDto } from 'src/dto/task.dto';
import { Task } from 'src/models/task.model';

@Injectable()
export class TaskService 
{
    private _todoConttrollerUrl = "http://localhost:4201/rest/Todo";

    constructor(private http: HttpClient)
    {
    }

    public GetAll() : Observable<Object>
    {
        return this.http.get( `${this._todoConttrollerUrl}/get-all` );
    }

    public Create( taskTitle: string ) : TaskDto
    {
        let taskDto: TaskDto = 
        {
            Id: 0,
            Title: taskTitle,
            IsDone: false
        };
        this.http.post( `${this._todoConttrollerUrl}/create`, taskDto ).subscribe();
        return taskDto;
    }

    public Complete( taskId: number ) : void
    {
        this.http.put( `${this._todoConttrollerUrl}/${taskId}/complete`, `` ).subscribe();
    }

    public Delete( taskId: number ) : void
    {
        this.http.delete( `${this._todoConttrollerUrl}/${taskId}/delete` ).subscribe();
    }

    public ParseDto( dto: TaskDto ) : Task
    {
        let task: Task = 
        {
            id: dto.Id,
            title: dto.Title,
            isDone: dto.IsDone
        };
        return task;
    }

    public ToDto( task: Task ) : TaskDto
    {
        let dto: TaskDto = 
        {
            Id: task.id,
            Title: task.title,
            IsDone: task.isDone
        };
        return dto;
    }
}