import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailsResover } from './_resolver/member-details.resolver';
import { MemberListResover } from './_resolver/member-list.resolver';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        children: [
            { path: 'members', component: MemberListComponent, resolve: {users: MemberListResover}},
            { path: 'members/:id', component: MemberDetailComponent, resolve: {user: MemberDetailsResover}},
            { path: 'messages', component: MessagesComponent},
            { path: 'lists', component: ListsComponent},
        ],
        canActivate: [AuthGuard]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'}
];
