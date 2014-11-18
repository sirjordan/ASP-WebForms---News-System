/// <reference path="jquery-2.1.1.js" />
$(document).ready(function () {
    var $articleTitle = $(".articleTitle");

    $articleTitle.click(function (e) {
        var $target = $(e.target);
        var clicked = $target.attr('data-info-clicked');
        if (clicked != 'clicked') {
            $target.attr('data-info-clicked', 'clicked');
            var $author = $("<span>");
            var $likesCount = $('<span>')
                .addClass('likePost');
            var $category = $('<span>');
            var $details = $('<div>')
                .text('Posted by:')
                .addClass('details');
            var articleId = $target.attr("data-info");

            var $likeBtn = $('<input type="button">')
                .val('I like this article!')
                .addClass('likePost').click(function (e) {
                    $.ajax({
                        url: '/api/articles/' + articleId,
                        type: 'put',
                        contentType: "application/json;charset=utf-8",
                        success: function (data) {
                            $likesCount += 1;
                        }
                    });
                });

            $.ajax({
                url: '/api/articles/' + articleId,
                type: 'get',
                dataType: 'json',
                success: function (data) {
                    if (data) {
                        $author.text("Posted By:" + data.Author);
                        $likesCount.text(data.Likes + ' likes');
                        $category.text("Category: " + data.Category);

                        $details.append($author);
                        $details.append($likesCount)
                        $details.append($likeBtn);
                        $details.append($category);
                        $target.parent().append($details);
                    } else {

                    }
                }
            });
        } else {
            $target.attr('data-info-clicked', '');
            $target.parent().find('.details').hide(200);
        }
    });

});