import React, { Component } from 'react';
import axios from 'axios';

export class Home extends Component {
    displayName = Home.name

    state = {
        posts: []
    }
    componentDidMount = async () => {
        const { data } = await axios.get('api/Scoop/GetTheScoop');
        this.setState({ posts: data });
        console.log(this.state.posts)
    }

    render() {
        return (
            <div>
                <h1> Welcome to the "adless" Lakewood Sccop</h1>
                <div className="row">
                    <table className="table table-hover table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>Image</th>
                                <th>Title</th>
                                <th>Comment count</th>
                                <th>Blurb</th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.posts.map((post, i) => {
                                return (
                                    <tr key={i}>
                                        <td>
                                            <img style={{ width: 300 }} src={post.image} />
                                        </td>
                                        <td>
                                            <a target="_blank" href={post.url}>
                                                {post.title}
                                            </a>
                                        </td>
                                        <td>
                                            {post.numberOfComments}
                                        </td>
                                        <td>
                                            {post.blurb}
                                        </td>
                                    </tr>
                                )
                            })}
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }
}