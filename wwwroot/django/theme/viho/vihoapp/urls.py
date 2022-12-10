# from django.conf.urls import url
from django.urls import path
from . import views

urlpatterns = [
    path('', views.defaultPage, name='default'),
    path('default/', views.default, name='default'),
    path('ecommerce/', views.ecommerce, name="ecommerce"),
    path('general/', views.general, name="general"),
    path('charts/', views.charts, name="charts"),
    path('box/', views.box, name="box"),
    path('rtl/', views.rtl, name="rtl"),
    path('dark/', views.dark, name="dark"),
    path('footer-dark/', views.footerdark, name="footerdark"),
    path('footer-light/', views.footerlight, name="footerlight"),
    path('footer-fix/', views.footerfix, name="footerfix"),
    path('state-color/', views.statecolor, name="statecolor"),
    path('typography/', views.typography, name="typography"),
    path('avatars/', views.avatars, name="avatars"),
    path('helper/', views.helper, name="helper"),
    path('grid_simple/', views.grid_simple, name="grid_simple"),
    path('tag-pills/', views.tagpills, name="tag-pills"),
    path('progressbar/', views.progressbar, name="progressbar"),
    path('modal/', views.modal, name="modal"),
    path('alert/', views.alert, name="alert"),
    path('popover/', views.popover, name="popover"),
    path('tooltip/', views.tooltip, name="tooltip"),
    path('spiners/', views.spiners, name="spiners"),
    path('dropdown/', views.dropdown, name="dropdown"),
    path('accordion/', views.accordion, name="accordion"),
    path('bootstraptab/', views.bootstraptab, name="bootstraptab"),
    path('linetab/', views.linetab, name="linetab"),
    path('navs/', views.navs, name="navs"),
    path('shadow/', views.shadow, name="shadow"),
    path('lists/', views.lists, name="lists"),
    path('scrollable/', views.scrollable, name="scrollable"),
    path('tree/', views.tree, name="tree"),
    path('bootstrapnotify/', views.bootstrapnotify, name="bootstrapnotify"),
    path('rating/', views.rating, name="rating"),
    path('dropzone/', views.dropzone, name="dropzone"),
    path('tour/', views.tour, name="tour"),
    path('sweetalert/', views.sweetalert, name="tour"),
    path('animated_modal/', views.animatedmodal, name="tour"),
    path('owlcarousel/', views.owlcarousel, name="owlcarousel"),
    path('ribbons/', views.ribbons, name="ribbons"),
    path('pagination/', views.pagination, name="pagination"),
    path('steps/', views.steps, name="steps"),
    path('breadcrumb/', views.breadcrumb, name="breadcrumb"),
    path('rangeslider/', views.rangeslider, name="rangeslider"),
    path('imagecropper/', views.imagecropper, name="imagecropper"),
    path('sticky/', views.sticky, name="sticky"),
    path('basiccard/', views.basiccard, name="basiccard"),
    path('creativecard/', views.creativecard, name="creativecard"),
    path('tabbedcard/', views.tabbedcard, name="tabbedcard"),
    path('draggablecard/', views.draggablecard, name="draggablecard"),
    path('timeline1/', views.timeline1, name="timeline1"),
    path('timeline2/', views.timeline2, name="timeline2"),
    path('formbuilder1/', views.formbuilder1, name="formbuilder1"),
    path('formbuilder2/', views.formbuilder2, name="formbuilder2"),
    path('pagebuild/', views.pagebuild, name="pagebuild"),
    path('buttonbuilder/', views.buttonbuilder, name="buttonbuilder"),
    path('animation/', views.animate, name="animate"),
    path('scrollreval/', views.scrollreval, name="scrollreval"),
    path('AOS/', views.AOS, name="AOS"),
    path('tilt/', views.tilt, name="tilt"),
    path('wow/', views.wow, name="wow"),
    path('flagicon/', views.flagicon, name="flagicon"),
    path('fontawesome/', views.fontawesome, name="fontawesome"),
    path('icoicon/', views.icoicon, name="icoicon"),
    path('themify/', views.themify, name="themify"),
    path('feather/', views.feather, name="feather"),
    path('whether/', views.whether, name="whether"),
    path('buttons/', views.buttons, name="buttons"),
    path('flat/', views.flat, name="flat"),
    path('edge/', views.edge, name="edge"),
    path('raised/', views.raised, name="raised"),
    path('group/', views.group, name="group"),
    path('apex/', views.apex, name="apex"),
    path('chartjs/', views.chartjs, name="chartjs"),
    path('chartist/', views.chartist, name="chartist"),
    path('flot/', views.flot, name="flot"),
    path('google/', views.google, name="google"),
    path('knob/', views.knob, name="knob"),
    path('morris/', views.morris, name="morris"),
    path('peity/', views.peity, name="peity"),
    path('sparkline/', views.sparkline, name="sparkline"),
    path('form_validation/', views.form_validation, name="form_validation"),
    path('base_input/', views.base_input, name="base_input"),
    path('radio_checkbox_control/', views.radio_checkbox_control, name="radio_checkbox_control"),
    path('input_group/', views.input_group, name="input_group"),
    path('megaoptions/', views.megaoptions, name="megaoptions"),
    path('datepicker/', views.datepicker, name="datepicker"),
    path('time_picker/', views.time_picker, name="time_picker"),
    path('datetimepicker/', views.datetimepicker, name="datetimepicker"),
    path('daterangepicker/', views.daterangepicker, name="daterangepicker"),
    path('touchspin/', views.touchspin, name="touchspin"),
    path('select2/', views.select2, name="select2"),
    path('switch/', views.switch, name="switch"),
    path('typeahead/', views.typeahead, name="typeahead"),
    path('clipboard/', views.clipboard, name="clipboard"),
    path('default_form/', views.default_form, name="default_form"),
#--------------------------------Forms & Table-----------------------------------------------
#--------------------------------Forms------------------------------------
#------------------------form-controls
path('form_validation', views.form_validation, name="form_validation"),
path('base_input', views.base_input, name="base_input"),
path('radio_checkbox_control', views.radio_checkbox_control, name="radio_checkbox_control"),
path('input_group', views.input_group, name="input_group"),
path('megaoptions', views.megaoptions, name="megaoptions"),

#---------------------------form widgets
path('datepicker', views.datepicker, name="datepicker"),
path('time_picker', views.time_picker, name="time_picker"),
path('datetimepicker', views.datetimepicker, name="datetimepicker"),
path('daterangepicker', views.daterangepicker, name="daterangepicker"),
path('touchspin', views.touchspin, name="touchspin"),
path('select2', views.select2, name="select2"),
path('switch', views.switch, name="switch"),
path('typeahead', views.typeahead, name="typeahead"),
path('clipboard', views.clipboard, name="clipboard"),
    

#--------------------------------form layout
path('default_form', views.default_form, name="default_form"),
path('form_wizards', views.form_wizards, name="form_wizards"),
path('form_wizard_two', views.form_wizard_two, name="form_wizard_two"),
path('form_wizard_three', views.form_wizard_three, name="form_wizard_three"),

#--------------------------------------Table--------------------------------------------------
#------------------------bootstrap table
path('basic_table', views.basic_table, name="basic_table"),
path('sizing_table', views.sizing_table, name="sizing_table"),
path('border_table', views.border_table, name="border_table"),
path('styling_table', views.styling_table, name="styling_table"),
path('table_components', views.table_components, name="table_components"),

#-------------------------data table
path('datatable_basic_init', views.datatable_basic_init, name="datatable_basic_init"),
path('datatable_advance', views.datatable_advance, name="datatable_advance"),
path('datatable_styling', views.datatable_styling, name="datatable_styling"),
path('datatable_AJAX', views.datatable_AJAX, name="datatable_AJAX"),
path('datatable_server_side', views.datatable_server_side, name="datatable_server_side"),
path('datatable_plugin', views.datatable_plugin, name="datatable_plugin"),
path('datatable_API', views.datatable_API, name="datatable_API"),
path('datatable_data_source', views.datatable_data_source, name="datatable_data_source"),

#---------------------------EXdata table
path('ext_autofill', views.ext_autofill, name="ext_autofill"),
path('ext_basic_button', views.ext_basic_button, name="ext_basic_button"),
path('ext_col_reorder', views.ext_col_reorder, name="ext_col_reorder"),
path('ext_fixed_header', views.ext_fixed_header, name="ext_fixed_header"),
path('ext_html_5_data_export', views.ext_html_5_data_export, name="ext_html_5_data_export"),
path('ext_key_table', views.ext_key_table, name="ext_key_table"),
path('ext_responsive', views.ext_responsive, name="ext_responsive"),
path('ext_row_reorder', views.ext_row_reorder, name="ext_row_reorder"),
path('ext_scroller', views.ext_scroller, name="ext_scroller"),

#-----------------------------jsgrid_table

    path('jsgrid_table', views.jsgrid_table, name="jsgrid_table"),
    path('projects', views.projects, name="projects"),
    path('projectcreate', views.projectcreate, name="projectcreate"), 
    path('file_manager', views.file_manager, name="file_manager"),
    path('kanban', views.kanban, name="kanban"),
    path('product_simple', views.product_simple, name="product_simple"),
    path('product_page', views.product_page, name="product_page"),
    path('list_products', views.list_products, name="list_products"),
    path('payment_details', views.payment_details, name="payment_details"),
    path('order_history', views.order_history, name="order_history"),
    path('invoice_template', views.invoice_template, name="invoice_template"),
    path('cart', views.cart, name="cart"),
    path('list_wish', views.list_wish, name="list_wish"),
    path('checkout', views.checkout, name="checkout"),
    path('pricing', views.pricing, name="pricing"),
    path('email_application', views.email_application, name="email_application"),
    path('email_readmail', views.email_readmail, name="email_readmail"),
    path('email_compose', views.email_compose, name="email_compose"),
    path('chat', views.chat, name="chat"),
    path('chat_video', views.chat_video, name="chat_video"),
    path('user_profile', views.user_profile, name="user_profile"),
    path('edit_profile', views.edit_profile, name="edit_profile"),
    path('user_cards', views.user_cards, name="user_cards"),
    path('bookmark', views.bookmark, name="bookmark"),
    path('contacts', views.contacts, name="contacts"),
    path('task', views.task, name="task"),
    path('calendar_basic', views.calendar_basic, name="calendar_basic"),
    path('social_app', views.social_app, name="social_app"),
    path('to_do_html', views.to_do_html, name="to_do_html"),
    path('to_do_database', views.to_do_database, name="to_do_database"),
    path('delete/<str:pk>/', views.deleteTask, name="delete"),
    path('updateTask/<str:pk>/', views.updateTask,name='updateTask'),
    path('markAllComplete/', views.markAllComplete, name='markAllComplete'),
    path('markAllIncomplete/', views.markAllIncomplete, name='markAllIncomplete'),

    path('search', views.search, name="search"),
        
#----------------------------------------------------Pages-----------------------------------


#-----------------landing-page
path('landing_page', views.landing_page , name="landing_page"),

#-----------------sample-page
path('sample_page', views.sample_page , name="sample_page"),

#-----------------internationalization
path('internationalization', views.internationalization, name="internationalization"),

#------------------starter-kit
path('starter_kit', views.starter_kit, name="starter_kit"),
path('starterkit_boxed', views.starterkit_boxed, name="starterkit_boxed"),
path('starterkit_footer_dark', views.starterkit_footer_dark, name="starterkit_footer_dark"),
path('starterkit_footer_fixed', views.starterkit_footer_fixed, name="starterkit_footer_fixed"),
path('starterkit_footer_light', views.starterkit_footer_light, name="starterkit_footer_light"),
path('starterkit_layout_dark', views.starterkit_layout_dark, name="starterkit_layout_dark"),
path('starterkit_layout_rtl', views.starterkit_layout_rtl, name="starterkit_layout_rtl"),

#--------------------Errror pae
path('error_page1', views.error_page1, name="error_page1"),
path('error_page2', views.error_page2, name="error_page2"),
path('error_page3', views.error_page3, name="error_page3"),
path('error_page4', views.error_page4, name="error_page4"),

#---------------------Authentication
path('login', views.loginview, name="login"),
path('login_one', views.login_one, name="login_one"),
path('login_two', views.login_two, name="login_two"),
path('login_bs_validation', views.login_bs_validation, name="login_bs_validation"),
path('login_tt_validation', views.login_tt_validation, name="login_tt_validation"),
path('login_validation', views.login_validation, name="login_validation"),
path('sign_up', views.sign_up, name="sign_up" ),
path('sign_one', views.sign_one, name="sign_one" ),
path('sign_two', views.sign_two, name="sign_two" ),
path('sign_wizard', views.sign_wizard, name="sign_wizard"),
path('unlock', views.unlock , name="unlock"),
path('forget_password', views.forget_password, name="forget_password"),
path('creat_password', views.creat_password, name="creat_password"),
path('maintenance', views.maintenance, name="maintenance"),
path('logout_view', views.logout_view, name="logout_view"),

#---------------------------------------comingsoon

path('comingsoon', views.comingsoon, name="comingsoon"),
path('comingsoon_video', views.comingsoon_video, name="comingsoon_video"),
path('comingsoon_img', views.comingsoon_img, name="comingsoon_img"),

#------------------------------------email template

path('basic_temp', views.basic_temp, name="basic_temp"),
path('email_header', views.email_header, name="email_header"),
path('template_email', views.template_email, name="template_email"),
path('template_email_2', views.template_email_2, name="template_email_2"),
path('ecommerce_temp', views.ecommerce_temp, name="ecommerce_temp"),
path('email_order', views.email_order, name="email_order"),


#------------------------------------------Miscellaneous----------------- -------------------------

#------------------------gallery

path('gallery_grid', views.gallery_grid, name="gallery_grid"),
path('grid_description', views.grid_description, name="grid_description"),
path('masonry_simple', views.masonry_simple, name="masonry_simple"),
path('masonry_disc', views.masonry_disc, name="masonry_disc"),
path('hover', views.hover, name="hover"),

#-------------------------Blog
path('blog_simple', views.blog_simple, name="blog_simple"),
path('blog_single', views.blog_single, name="blog_single"),
path('add_post', views.add_post, name="add_post"),

#-------------------------faq
path('FAQ', views.FAQ, name="FAQ"),

#-------------------------job serch

path('job_cards', views.job_cards, name="job_cards"),
path('job_list', views.job_list, name="job_list"),
path('job_details', views.job_details, name="job_details"),
path('apply', views.apply, name="apply"),

#-------------------------Learning
path('learning_list', views.learning_list, name="learning_list"),
path('learning_detailed', views.learning_detailed, name="learning_detailed"),

#-------------------------maps
path('maps_js', views.maps_js, name="maps_js"),
path('vector_maps', views.vector_maps, name="vector_maps"),

#------------------------------------Editors
path('summernote', views.summernote, name="summernote"),
path('ckeditor', views.ckeditor, name="ckeditor"),
path('simple_mde', views.simple_mde, name="simple_mde"),
path('ace_code', views.ace_code, name="ace_code"),


#-----------------------------knowledgebase
path('knowledgebase', views.knowledgebase, name="knowledgebase"),
path('know_category', views.know_category, name="knowledgebase"),
path('know_detail', views.know_detail, name="knowledgebase"),

#-----------------------------support-ticket
path('support_ticket', views.support_ticket, name="support_ticket"),

]