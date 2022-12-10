<?php $__env->startSection('title'); ?>Tooltip
 <?php echo e($title); ?>

<?php $__env->stopSection(); ?>

<?php $__env->startPush('css'); ?>
<?php $__env->stopPush(); ?>

<?php $__env->startSection('content'); ?>
	<?php $__env->startComponent('components.breadcrumb'); ?>
		<?php $__env->slot('breadcrumb_title'); ?>
			<h3>Tooltip</h3>
		<?php $__env->endSlot(); ?>
		<li class="breadcrumb-item">Base</li>
		<li class="breadcrumb-item active">Tooltip</li>
	<?php echo $__env->renderComponent(); ?>

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header pb-0">
                        <h5>Basic Tooltip</h5>
                    </div>
                    <div class="card-body btn-showcase">
                        <button class="example-popover btn btn-primary" type="button" data-container="body" data-bs-toggle="tooltip" data-bs-placement="top" title="Popover title">Hover Me</button>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header pb-0">
                        <h5>Directions</h5>
                    </div>
                    <div class="card-body btn-showcase">
                        <button class="btn btn-primary" type="button" data-bs-toggle="tooltip" data-bs-placement="top" title="Tooltip on top">Tooltip on top</button>
                        <button class="btn btn-primary" type="button" data-bs-toggle="tooltip" data-bs-placement="right" title="Tooltip on right">Tooltip on right</button>
                        <button class="btn btn-primary" type="button" data-bs-toggle="tooltip" data-bs-placement="bottom" title="Tooltip on bottom">Tooltip on bottom</button>
                        <button class="btn btn-primary" type="button" data-bs-toggle="tooltip" data-bs-placement="left" title="Tooltip on left">Tooltip on left</button>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header pb-0">
                        <h5>HTML elements</h5>
                    </div>
                    <div class="card-body btn-showcase">
                        <button class="btn btn-primary" type="button" data-bs-toggle="m-tooltip" data-bs-trigger="click" data-bs-placement="top" title="&lt;em&gt;Tooltip&lt;/em&gt; &lt;u&gt;with&lt;/u&gt; &lt;b&gt;HTML&lt;/b&gt;" data-bs-html="true" data-content="And here's some amazing &lt;b&gt;HTML&lt;/b&gt; content. It's very &lt;code&gt;engaging&lt;/code&gt;. Right?" data-original-title="Tooltip &lt;b&gt;with&lt;/b&gt; &lt;code&gt;HTML&lt;/code&gt;">Click me</button>
                        <button class="btn btn-primary" type="button" data-bs-toggle="m-tooltip" data-bs-trigger="click" data-bs-placement="right" title="&lt;em&gt;Tooltip&lt;/em&gt; &lt;u&gt;with&lt;/u&gt; &lt;b&gt;HTML&lt;/b&gt;" data-bs-html="true" data-content="And here's some amazing &lt;b&gt;HTML&lt;/b&gt; content. It's very &lt;code&gt;engaging&lt;/code&gt;. Right?" data-original-title="Tooltip &lt;b&gt;with&lt;/b&gt; &lt;code&gt;HTML&lt;/code&gt;">Click me</button>
                        <button class="btn btn-primary" type="button" data-bs-toggle="m-tooltip" data-bs-trigger="click" data-bs-placement="bottom" title="&lt;em&gt;Tooltip&lt;/em&gt; &lt;u&gt;with&lt;/u&gt; &lt;b&gt;HTML&lt;/b&gt;" data-bs-html="true" data-content="And here's some amazing &lt;b&gt;HTML&lt;/b&gt; content. It's very &lt;code&gt;engaging&lt;/code&gt;. Right?" data-original-title="Tooltip &lt;b&gt;with&lt;/b&gt; &lt;code&gt;HTML&lt;/code&gt;">Click me</button>
                        <button class="btn btn-primary" type="button" data-bs-toggle="m-tooltip" data-bs-trigger="click" data-bs-placement="left" title="&lt;em&gt;Tooltip&lt;/em&gt; &lt;u&gt;with&lt;/u&gt; &lt;b&gt;HTML&lt;/b&gt;" data-bs-html="true" data-content="And here's some amazing &lt;b&gt;HTML&lt;/b&gt; content. It's very &lt;code&gt;engaging&lt;/code&gt;. Right?" data-original-title="Tooltip &lt;b&gt;with&lt;/b&gt; &lt;code&gt;HTML&lt;/code&gt;">Click me</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

<?php $__env->startPush('scripts'); ?> 
<script src="<?php echo e(asset('assets/js/tooltip-init.js')); ?>"></script>
<?php $__env->stopPush(); ?>

<?php $__env->stopSection(); ?>

<?php echo $__env->make('layouts.admin.master', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/webiotspc/Desktop/hetvi/laravel/Viho-Laravel-8/theme/resources/views/admin/ui-kits/tooltip.blade.php ENDPATH**/ ?>